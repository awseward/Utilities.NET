﻿using System;
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

        public static void Add(this IDictionary<string, string> dict, string key, object value)
        {
            if (value == null) { return; }

            dict.Add(key, value.ToString());
        }

        /// <remarks>Adapted from a stackoverlow answer.</remarks>
        /// <see cref="http://stackoverflow.com/a/3804455"/>
        public static bool IsEquivalentTo<TKey, TValue>(this IDictionary<TKey, TValue> thisD, IDictionary<TKey, TValue> thatD)
        {
            if (thisD == thatD) return true;
            if (thisD == null || thatD == null) return false;
            if (thisD.Count != thatD.Count) return false;

            var comparer = EqualityComparer<TValue>.Default;

            foreach (KeyValuePair<TKey, TValue> kvp in thisD)
            {
                TValue thatValue;
                if (!thatD.TryGetValue(kvp.Key, out thatValue)) return false;
                if (!comparer.Equals(kvp.Value, thatValue)) return false;
            }
            return true;
        }

        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumable, Func<T, T> transformation)
        {
            return enumable.EveryOther(transformation, true);
        }

        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumable, Func<T, T> transformation, bool affectsZero)
        {
            return enumable.EveryOther(transformation, affectsZero, t => false);
        }

        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumable, Func<T, T> transformation, bool affectsZero, Func<T, bool> skip)
        {
            var doSomething = !affectsZero;

            foreach (var item in enumable)
            {
                var shouldSkip = skip(item);

                if (!shouldSkip) { doSomething = !doSomething; }
                yield return (!shouldSkip && doSomething) ? transformation(item) : item;
            }
        }

        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumable, Action<T> action)
        {
            return enumable.EveryOther(action, true);
        }

        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumable, Action<T> action, bool affectsZero)
        {
            return enumable.EveryOther(action, affectsZero, t => false);
        }

        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumable, Action<T> action, bool affectsZero, Func<T, bool> skip)
        {
            var doSomething = affectsZero;

            foreach (var item in enumable)
            {
                if (skip(item)) { continue; }

                if (doSomething) { action(item); }
                doSomething = !doSomething;
            }

            return enumable;
        }

        #region Obsolete

        [Obsolete]
        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumable, bool affectsZero, Func<T, T> transformation)
        {
            var doSomething = !affectsZero;

            foreach (var item in enumable)
            {
                doSomething = !doSomething;
                yield return (doSomething) ? transformation(item) : item;
            }
        }

        [Obsolete]
        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumable, bool affectsZero, Action<T> action)
        {
            var doSomething = affectsZero;

            foreach (var item in enumable)
            {
                if (doSomething) { action(item); }
                doSomething = !doSomething;
            }

            return enumable;
        }

        #endregion
    }
}
