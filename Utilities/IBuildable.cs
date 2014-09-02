using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public interface IBuildable<TIn, TOut>
    {
        TOut Build(TIn item);
    }
}
