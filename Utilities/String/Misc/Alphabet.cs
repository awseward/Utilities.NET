using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String.Misc
{
    public static class Alphabet
    {
        public static IEnumerable<char> Lower
        {
            get
            {
                return AlphabetStartingWith('a');
            }
        }

        public static IEnumerable<char> Upper
        {
            get
            {
                return AlphabetStartingWith('A');
            }
        }

        private static IEnumerable<char> AlphabetStartingWith(char ch)
        {
            for (int i = (int) ch; i < ch + 26; i++)
            {
                yield return (char) i;
            }
        }
    }
}
