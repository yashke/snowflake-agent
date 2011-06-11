using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crystals;

namespace SnowCrystals
{
    class MainPanelController
    {
        Habitat environment;
        GrowthSimulation view;

        public MainPanelController(GrowthSimulation v,  Habitat env)
        {
            view = v;
            environment = env;
        }
    }
}
