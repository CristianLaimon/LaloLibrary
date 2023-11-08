﻿using LaloLibrary.DataStructures;
using LaloLibrary.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaloLibrary.DataStuctures
{
    public class LinkedDoubleCircularList<T> : IEnumerable<T>
    {
        private DualNode<T> first;

        public LinkedDoubleCircularList() { }

        public void Add(params T[] arrayData)
        {
            foreach(T data in arrayData)
            {
                DualNode<T> newNode = new DualNode<T>(data);

                if(IsEmpty())
                {
                    first = newNode;
                    first.NextNode = first;
                    first.BackNode = first;
                }
                else
                {
                    DualNode<T> previousLastNode = GetLastNode();
                    newNode.NextNode = first;
                    newNode.BackNode = previousLastNode;

                    first.BackNode = newNode;
                    previousLastNode.NextNode = newNode;
                }
            }
        }
        public bool Remove(T removeData)
        {
            if (IsEmpty()) return false;

            if (Count() == 1)
            {
                first = null;
                return true;
            }

            DualNode<T> pointer = first;
            do
            {
                if(pointer.Data.Equals(removeData))
                {
                    pointer.BackNode.NextNode = pointer.NextNode;
                    pointer.NextNode.BackNode = pointer.BackNode;

                    if(pointer == first)
                    {
                        first = pointer.NextNode;
                    }

                    pointer.NextNode = null;
                    pointer.BackNode = null;

                    return true;
                }
                pointer = pointer.NextNode;

            } while (pointer != first);

            return false;
        }

        public bool AddAfter(T dataToStop, T dataAfter)
        {
            if (IsEmpty()) return false;

            DualNode<T> pointer = first;
            do
            {
                if(pointer.Data.Equals(dataToStop))
                {
                    DualNode<T> nextNode = pointer.NextNode;
                    DualNode<T> nodeToInsert = new DualNode<T>(dataAfter);

                    pointer.NextNode = nodeToInsert;
                    nextNode.BackNode = nodeToInsert;

                    nodeToInsert.NextNode = nextNode;
                    nodeToInsert.BackNode = pointer;

                    return true;
                }

                pointer = pointer.NextNode;
            }while(pointer != first);

            return false;

        }

        public bool AddBefore(T dataToStop, T dataBefore)
        {
            if (IsEmpty()) return false;

            DualNode<T> pointer = first;
            do
            {
                if (pointer.Data.Equals(dataToStop))
                {
                    DualNode<T> backTemp = pointer.BackNode;
                    DualNode<T> nodeToInsert = new DualNode<T>(dataBefore);

                    backTemp.NextNode = nodeToInsert;
                    pointer.BackNode = nodeToInsert;

                    nodeToInsert.NextNode = pointer;
                    nodeToInsert.BackNode = backTemp;

                    return true;
                }

                pointer = pointer.NextNode;
            } while (pointer != first);

            return false;
        }

        public void Clear() => first = null;
        public bool Contains(T data)
        {
            if (IsEmpty()) return false;

            DualNode<T> pointer = first;
            do
            {
                if (pointer.Data.Equals(data))
                {
                    return true;
                }
                pointer = pointer.NextNode;
            } while (pointer != first);

            return false;
        }

        public int Count()
        {
            if (IsEmpty()) return 0;

            int count = 0;
            DualNode<T> pointer = first;
            do
            {
                count++;
                pointer = pointer.NextNode;

            } while (pointer != first);

            return count;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public T[] MakeToArray()
        {
            if (IsEmpty()) return new T[0];

            T[] array = new T[Count()];
            DualNode<T> tempPointer = first;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = tempPointer.Data;
                tempPointer = tempPointer.NextNode;
            }
            return array;
        }

        public void RemoveLast()
        {
            if (IsEmpty()) return;

            DualNode<T> lastNode = GetLastNode();
            Remove(lastNode.Data);
        }

        private DualNode<T> GetLastNode()
        {
            if(!IsEmpty())
            {
                DualNode<T> pointer = first;

                do
                {
                    pointer = pointer.NextNode;
                } while (pointer.NextNode != first);

                return pointer;
            }
            else
            {
                throw new LinkedListException("Can't get last node from an empty LinkedDoubleCircularlist");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            DualNode<T> current = first;

            if (IsEmpty())
            {
                yield break;
            }

            do
            {
                yield return current.Data;
                current = current.NextNode;
            } while (current != first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                DualNode<T> pointer = first;

                for(int i = 0; i < index; i++)
                {
                    pointer = pointer.NextNode;
                }

                return pointer.Data;
            }
            set
            {
                DualNode<T> pointer = first;

                for (int i = 0; i < index; i++)
                {
                    pointer = pointer.NextNode;
                }

                pointer.Data = value;
            }
        }

        public static LinkedDoubleCircularList<T> operator +(LinkedDoubleCircularList<T> list1, LinkedDoubleCircularList<T> list2)
        {
            list1.Add(list2.MakeToArray());
            return list1;
        }
    }
}
