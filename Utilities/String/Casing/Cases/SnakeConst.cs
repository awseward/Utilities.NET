﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.String.Casing
{
    public class SnakeConst : Snake
    {
        public override string Build(IEnumerable<string> input)
        {
            return base.Build(input).ToUpper();
        }
    }
}
