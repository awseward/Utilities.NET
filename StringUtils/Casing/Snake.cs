using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringUtils.Casing
{
    public class Snake : StringCase
    {
        public override IEnumerable<string> Split(string input)
        {
            return input.Split('_');
        }

        public override string Build(IEnumerable<string> input)
        {
            return string.Join("_", input.Select(str => str.ToLower()));
        }
    }
}
