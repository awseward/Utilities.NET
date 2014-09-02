using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String.Casing
{
    public abstract class StringCase : IRebuildable<IEnumerable<string>, string>
    {
        public abstract IEnumerable<string> Split(string input);

        public abstract string Build(IEnumerable<string> input);

        public virtual IEnumerable<string> Deconstruct(string input)
        {
            return Split(input);
        }

    }
}
