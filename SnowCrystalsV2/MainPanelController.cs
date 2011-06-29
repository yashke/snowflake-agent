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

            public void MoleculeAdded(Molecule molecule)
            {
                var presenter = new MoleculePresenter(molecule);
                view.AllMoleculePresenters.Add(presenter);
                Logger.Log("All molecules count", view.AllMoleculePresenters.Count);
                view.StatusMessage(String.Format("{0}", view.AllMoleculePresenters.Count));
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

        class ParametersChangedListener : IParametersChangedCloseListener
        {
            Habitat habitat;

            public ParametersChangedListener(Habitat env)
            {
                habitat = env;
            }

            public double DesireChanged(double newDesire)
            {
                habitat.Desire = newDesire;
                return habitat.Desire;
            }

            public double DesireRadiusChanged(double newDesireRadiusScale)
            {
                habitat.DesireRadius = Molecule.RADIUS * newDesireRadiusScale;
                return habitat.DesireRadius;
            }
        }

        public MainPanelController(GrowthSimulation v, Habitat env)
        {
            view = v;
            environment = env;
            environment.AddNewBindingListener(new BindingListener(view));
            view.AddCloseListener(new CloseListener(env));
            view.AddParametersChangedListener(new ParametersChangedListener(env));
            
            view.StatusMessage("Started");
        }
    }

    public interface IParametersChangedCloseListener
    {
         double DesireChanged(double newDesire);

         double DesireRadiusChanged(double newDesireRadiusScale);

    }
}
