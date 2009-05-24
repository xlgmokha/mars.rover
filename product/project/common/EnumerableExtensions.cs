using System;
using System.Collections.Generic;

namespace mars.rover.common
{
    static public class EnumerableExtensions
    {
        static public void each<T>(this IEnumerable<T> items, Action<T> command)
        {
            foreach (var item in items) command(item);
        }
    }
}