using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String.Casing
{
    public class Pascal : StringCase
    {
        public override IEnumerable<string> Split(string input)
        {
            var words = new List<string>();
            var index = 0;

            while (index < input.Length)
            {
                var sub = input.Substring(index);
                var head = sub.Take(1).Single();
                var tail = new string(sub.Skip(1).TakeWhile(ch => char.IsLower(ch)).ToArray());

                var word = head + tail;
                words.Add(word);
                index += word.Length;
            }

            return words;
        }

        public override string Build(IEnumerable<string> input)
        {
            var builder = new StringBuilder();
            foreach (var word in input)
            {
                builder.Append(word.FirstToUpper());
            }

            return builder.ToString();
        }
    }
}
