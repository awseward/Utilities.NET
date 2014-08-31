using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Collections
{
    public static class Extensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return collection.Count() == 0;
        }

        public static IEnumerable<T> Tail<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() <= 1) { return Enumerable.Empty<T>(); }

            return collection.Skip(1);
        }
    }
}
