using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringUtils.Casing
{
    public class Space : StringCase
    {
        public override IEnumerable<string> Split(string input)
        {
            return input.Split(' ');
        }

        public override string Build(IEnumerable<string> input)
        {
            return string.Join(" ", input);
        }
    }
}
