using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    interface IPositionChangeListener
    {
        void PositionChanged(double x, double y);
    }
}
