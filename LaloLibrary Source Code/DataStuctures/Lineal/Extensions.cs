﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaloLibrary.DataStructures.Lineal
{
    public static class Extensions
    {
        public static LinkedCircularList<T> ToCircularList<T>(this T[] array)
        {
            LinkedCircularList <T> list = new();
            list.Add(array);
            return list;
        }
    }
}