﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String.Casing
{
    public static class Extensions
    {
        public static string FirstToUpper(this string str)
        {
            if (str.Length > 1)
            {
                if (char.IsUpper(str[0])) { return str; }

                return char.ToUpper(str[0]) + str.Substring(1);
            }

            return str.ToUpper();
        }

        public static string FirstOnlyToUpper(this string str)
        {
            if (str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1).ToLower();
            }

            return str.ToUpper();
        }
    }
}
