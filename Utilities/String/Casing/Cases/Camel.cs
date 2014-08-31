using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String.Casing
{
    public class Camel : Pascal
    {
        public override string Build(IEnumerable<string> input)
        {
            var builder = new StringBuilder();
            foreach (var word in input.Take(1))
            {
                builder.Append(word.ToLower());
            }

            builder.Append(base.Build(input.Skip(1)));

            return builder.ToString();
        }
    }
}
