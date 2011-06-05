using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowCrystals
{
    class DensityBarController
    {
        class DensityListener : DensityChangeListener
        {
            Crystals.Environment environment;

            public DensityListener(Crystals.Environment env)
            {
                environment = env;
            }

            public void Changed(Object sender, int value)
            {
                environment.Density = value;
            }
        }

        private GrowthSimulation view;
        private DensityListener densityListener;
        private Crystals.Environment environment;

        public DensityBarController(GrowthSimulation v, Crystals.Environment env)
        {
            view = v;
            environment = env;
        }

        public void BindListeners()
        {
            densityListener = new DensityListener(environment);
            view.AddDensityChangeListener(densityListener);
        }
    }
}
