﻿using System;
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

        class BindingListener : NewBindingListener
        {
            private GrowthSimulation view;

            public BindingListener(GrowthSimulation v)
            {
                view = v;
            }

            public void NewBinding()
            {
                view.Invalidate();
            }
        }

        public MainPanelController(GrowthSimulation v,  Habitat env)
        {
            view = v;
            environment = env;
            environment.AddNewBindingListener(new BindingListener(view));
        }
    }
}
