using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Casing.Cases
{
    public class LeadingUnderscoreCamel : Camel
    {
        public override string Build(IEnumerable<string> input)
        {
            return string.Format("_{0}", base.Build(input));
        }
    }
}
