using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    interface IRebuildable<TIn, TOut> : ISplittable<TOut, TIn> { }
}
