using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    public interface MoleculeAddedListener
    {
        void MoleculeAdded(Molecule molecule);
    }
}
