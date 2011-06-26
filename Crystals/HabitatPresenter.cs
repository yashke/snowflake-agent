using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    public class HabitatPresenter
    {
        Habitat Habitat;

        public HabitatPresenter(Habitat habitat)
        {
            Habitat = habitat;
        }

       /* public List<MoleculePresenter> FlakeMoleculePresenters()
        {
            List<MoleculePresenter> presenters = new List<MoleculePresenter>();
            foreach (Molecule molecule in Habitat.FlakeMolecules())
            {
                presenters.Add(molecule.Presenter);
            }
            return presenters;
        }*/
    }
}
