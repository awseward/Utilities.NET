using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String
{
    public class StringTransformer
    {
        protected StringTransformer() { }

        public StringTransformer(Func<string, string> transform)
        {
            _transform = transform;
        }

        private readonly Func<string, string> _transform;

        public virtual Func<string, string> Transform { get { return _transform; } }
    }
}
