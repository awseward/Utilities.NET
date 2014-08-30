using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringUtils.Casing
{
    public class Sentence : Space
    {
        public override string Build(IEnumerable<string> input)
        {
            var first = input.Take(1).Single();

            string capFirst;
            if (first.Length > 1)
            {
                capFirst = char.ToUpper(first.Take(1).Single()) + first.Substring(1);
            }
            else
            {
                capFirst = first.ToUpper();
            }

            return string.Join(" ", capFirst, base.Build(input.Skip(1)));
        }
    }
}
