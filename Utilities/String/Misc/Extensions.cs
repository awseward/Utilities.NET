using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String.Misc
{
    public static class Extensions
    {
        public static int Count(this string str, char target)
        {
            return str.Where(ch => ch == target).Count();
        }

        public static IDictionary<char, int> CharacterCounts(this string str, IEnumerable<char> charSet)
        {
            var dict = new Dictionary<char, int>();

            foreach (var ch in charSet)
            {
                dict.Add(ch, str.Count(ch));
            }

            return dict;
        }

        public static IDictionary<char, int> LowerAlphaCounts(this string str)
        {
            return str.CharacterCounts(Alphabet.Lower);
        }

        public static IDictionary<char, int> UpperAlphaCounts(this string str)
        {
            return str.CharacterCounts(Alphabet.Upper);
        }

        public static IDictionary<char, int> AlphaCounts(this string str)
        {
            var upper = str.UpperAlphaCounts();
            var lower = str.LowerAlphaCounts();

            return upper.Concat(lower).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public static IDictionary<char, int> CaseInsensitiveAlphaCounts(this string str)
        {
            return str.ToUpper().UpperAlphaCounts();
        }
    }
}
