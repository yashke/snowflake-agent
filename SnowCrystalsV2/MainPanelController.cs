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
            public void NewBinding(List<Molecule> molecules)
            {
                Logger.Log("BindingListener.NewBinding >> Molecules", molecules.Count);
                List<MoleculePresenter> presenters = new List<MoleculePresenter>();
                foreach (Molecule molecule in molecules)
                {
                    var presenter = new MoleculePresenter(molecule);
                    presenters.Add(presenter);
                    Logger.Log("Point", presenter.Point);
                    view.StatusMessage(String.Format("{0}", presenter.Point));
                }
                view.MoleculePresenters = presenters;
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
