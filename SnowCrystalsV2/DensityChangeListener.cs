using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowCrystals
{
    public interface DensityChangeListener
    {
        void Changed(Object sender, int currentValue);
    }
}
