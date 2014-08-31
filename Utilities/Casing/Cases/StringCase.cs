using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Casing
{
    public abstract class StringCase
    {
        public abstract IEnumerable<string> Split(string input);

        public abstract string Build(IEnumerable<string> input);
    }
}
