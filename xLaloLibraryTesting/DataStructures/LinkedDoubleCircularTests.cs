﻿using FluentAssertions;
using LaloLibrary.DataStuctures;

namespace DataStructures
{
    public class LinkedDoubleCircularTests
    {
        private LinkedDoubleCircularList<int> circularList = new();

        [Theory]
        [InlineData(new int[] { 1, 2, 3 })]
        private void Add(int[] input)
        {
            circularList.Add(input);
            circularList.Add(1, 2, 3, 4, 5, 3, 2, 2, 2, 2, 2, 2, 2, 2);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2, 4, 5 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 2, 3, 4, 5 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 1, 2, 3, 4, 5 }, false)]
        [InlineData(new int[] { 1 }, 1, new int[] { }, true)]
        private void Remove(int[] input, int remove, int[] output, bool boolean)
        {
            circularList.Add(input);
            circularList.Remove(remove).Should().Be(boolean);
            circularList.MakeToArray().Should().BeEquivalentTo(output);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [InlineData(new int[] { 1 }, new int[] { })]
        [InlineData(new int[] { }, new int[] { })]
        private void RemoveLast(int[] input, int[] output)
        {
            circularList.Add(input);
            circularList.RemoveLast();
            circularList.MakeToArray().Should().BeEquivalentTo(output);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, 100, new int[] { 1, 2, 3, 100, 4, 5 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, 100, new int[] { 1, 2, 3, 4, 100, 5 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, 100, new int[] { 100, 1, 2, 3, 4, 5 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 7, 100, new int[] { 1, 2, 3, 4, 5 }, false)]
        private void AddBefore(int[] input, int numberToStop, int numberBehing, int[] output, bool boolean)
        {
            circularList.Add(input);
            circularList.AddBefore(numberToStop, numberBehing).Should().Be(boolean);
            circularList.MakeToArray().Should().BeEquivalentTo(output);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, 100, new int[] { 1, 2, 3, 4, 100, 5 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, 100, new int[] { 1, 2, 3, 4, 5, 100 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, 100, new int[] { 1, 100, 2, 3, 4, 5 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 7, 100, new int[] { 1, 2, 3, 4, 5 }, false)]
        private void AddAfter(int[] input, int numberToStop, int numberAfter, int[] output, bool boolean)
        {
            circularList.Add(input);
            circularList.AddAfter(numberToStop, numberAfter).Should().Be(boolean);
            circularList.MakeToArray().Should().BeEquivalentTo(output);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 7, false)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 0, false)]
        private void Contains(int[] input, int numberToFind, bool boolean)
        {
            circularList.Add(input);
            circularList.Contains(numberToFind).Should().Be(boolean);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { })]
        private void Clear(int[] input)
        {
            circularList.Clear();
            circularList.MakeToArray().Should().BeEquivalentTo(
                new int[]
                {
                }
                );
            circularList.Count().Should().Be(0);
            circularList.IsEmpty().Should().BeTrue();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { })]
        private void Clear2(int[] input)
        {
            circularList.Clear();
            circularList.MakeToArray().Should().BeEquivalentTo(
                new int[]
                {
                }
                );
            circularList.Count().Should().Be(0);
            circularList.IsEmpty().Should().BeTrue();

            circularList.Add(1, 2, 3);
            circularList.MakeToArray().Should().BeEquivalentTo(
                new int[]
                {
                    1,2,3
                }
                );
            circularList.Count().Should().Be(3);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { })]
        private void UseIndex(int[] input)
        {
            circularList.Add(input);

            if (circularList.IsEmpty())
            {
                Action action = () => circularList[0].Should();
                action.Should().Throw<NullReferenceException>();
            }
        }

        [Fact]
        private void Inverse()
        {
            circularList.Add(1);
            circularList.Add(2);
            circularList.Add(3);
            circularList.Add(4);
            circularList.Add(5);

            circularList.InverseList();

            circularList.MakeToArray().Should().NotBeEmpty();
            circularList.MakeToArray().Should().BeInDescendingOrder();
            circularList.MakeToArray().Should().BeEquivalentTo(
                new int[]
                {
                    5,4,3,2,1
                }
                );
        }
    }
}