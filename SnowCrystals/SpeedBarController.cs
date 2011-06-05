using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crystals;

namespace SnowCrystals
{
    class SpeedBarController
    {
        class SpeedListener : SpeedChangeListener
        {
            Habitat environment;

            public SpeedListener(Habitat env)
            {
                environment = env;
            }

            public void Changed(Object sender, int value)
            {
                environment.Speed = value;
            }
        }

        private Habitat environment;
        private SpeedListener speedListener;
        private GrowthSimulation view;

        public SpeedBarController(GrowthSimulation v, Habitat env)
        {
            view = v;
            environment = env;
        }

        public void BindListeners() 
        {
            speedListener = new SpeedListener(environment);
            view.AddSpeedChangeListener(speedListener);
        }
    }
}
