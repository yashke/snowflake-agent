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

        class BindingListener : NewBindingListener
        {
            private GrowthSimulation view;

            public BindingListener(GrowthSimulation v)
            {
                view = v;
            }
            public void NewBinding(Molecule molecule)
            {
                var presenter = new MoleculePresenter(molecule);
                
                Logger.Log("Flake point", presenter.Point);
                view.StatusMessage(String.Format("{0}", presenter.Point));
                
                view.MoleculePresenters.Add(presenter);
                view.RepaintBindings();
            }
        }

        class CloseListener : ICloseListener
        {
            Habitat habitat;

            public CloseListener(Habitat env)
            {
                habitat = env;
            }

            public void ProgramClosed()
            {
                habitat.ThreadStop();
            }
        }

        public MainPanelController(GrowthSimulation v,  Habitat env)
        {
            view = v;
            environment = env;
            environment.AddNewBindingListener(new BindingListener(view));
            view.AddCloseListener(new CloseListener(env));
            view.StatusMessage("Started");
        }
    }
}
