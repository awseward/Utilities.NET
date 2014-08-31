using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String.Casing
{
    public class CaseTransformer<TIn, TOut> : StringTransformer
        where TIn  : StringCase, new()
        where TOut : StringCase, new()
    {
        private readonly TIn _in = new TIn();

        private readonly TOut _out = new TOut();

        public override Func<string, string> Transform
        {
            get { return str => _out.Build(_in.Split(str)); }
        }
    }
}
