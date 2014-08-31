using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.Collections;

namespace Utilities.String
{
    public static class Extensions
    {
        public static string EveryOther(this string str, Func<char, char> transformation)
        {
            return str.EveryOther(transformation, true);
        }

        public static string EveryOther(this string str, Func<char, char> transformation, bool affectsZero)
        {
            return str.EveryOther(transformation, affectsZero, ch => false);
        }

        public static string EveryOther(this string str, Func<char, char> transformation, bool affectsZero, Func<char, bool> skip)
        {
            var chars = str.EveryOther<char>(transformation, affectsZero, skip).ToArray();
            return new string(chars);
        }
    }
}
