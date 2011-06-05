using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crystals;

namespace SnowCrystals
{
    class DensityBarController
    {
        class DensityListener : DensityChangeListener
        {
            Habitat environment;

            public DensityListener(Habitat env)
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
        private Habitat environment;

        public DensityBarController(GrowthSimulation v, Habitat env)
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
