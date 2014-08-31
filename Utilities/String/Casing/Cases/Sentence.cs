using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String.Casing
{
    public class Sentence : Space
    {
        public override string Build(IEnumerable<string> input)
        {
            if (input.Count() == 0) { return string.Empty; }

            var first = input.First().FirstToUpper();
            return string.Join(" ", first, base.Build(input.Skip(1)));
        }
    }
}
