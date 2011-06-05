using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowCrystals
{
    public interface SpeedChangeListener
    {
        void Changed(Object sender, int currentValue);
    }
}
