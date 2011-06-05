using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowCrystals
{
    class SpeedBarController
    {
        class SpeedListener : SpeedChangeListener
        {
            Crystals.Environment environment;

            public SpeedListener(Crystals.Environment env)
            {
                environment = env;
            }

            public void Changed(Object sender, int value)
            {
                environment.Speed = value;
            }
        }

        private Crystals.Environment environment;
        private SpeedListener speedListener;
        private GrowthSimulation view;

        public SpeedBarController(GrowthSimulation v, Crystals.Environment env)
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
