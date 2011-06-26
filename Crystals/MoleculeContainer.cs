using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;

namespace Crystals
{
    public class MoleculeContainer : ICollection<Molecule>
    {
        class AttachingListener : MoleculeAttachedListener
        {
            private Habitat habitat;

            public AttachingListener(Habitat env)
            {
                habitat = env;
            }

            public void MoleculeAttached(Molecule molecule)
            {
                habitat.Molecules.FlakeMoleculesCount++;
                habitat.FireNewBinding(molecule);
            }
        }

        public ArrayList container;
        public int FlakeMoleculesCount = 0;
        public Habitat Habitat;
        private List<MoleculeAddedListener> MoleculeAddedListeners = new List<MoleculeAddedListener>();

        public MoleculeContainer(Habitat habitat)
        {
            container = new ArrayList();
            Habitat = habitat;
        }

        public Molecule this[int index]
        {
            get
            {
                return (Molecule)container[index];
            }
        }

        public Molecule GetMoveInterferer(Molecule molecule)
        {
            foreach (Molecule mol in container)
            {
                if (mol != molecule && molecule.IsNearConflict(mol))
                {
                    return mol;
                }
            }
            return null;
        }

        #region ICollection<Molecule> Members

        public void Add(Molecule item)
        {
            container.Add(item);
            FireMoleculeAdded(item);
            item.AddMoleculeAttachedListener(new AttachingListener(Habitat));
        }

        public void Clear()
        {
            container.Clear();
        }

        public bool Contains(Molecule item)
        {
            return container.Contains(item);
        }

        public void CopyTo(Molecule[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return container.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Molecule item)
        {
             container.Remove(item);
             return true;
        }

        public void FireMoleculeAdded(Molecule molecule)
        {
            foreach (MoleculeAddedListener listener in MoleculeAddedListeners)
            {
                listener.MoleculeAdded(molecule);
            }
        }

        public void AddMoleculeAddedListener(MoleculeAddedListener listener)
        {
            MoleculeAddedListeners.Add(listener);
        }

        /*public List<Molecule> FlakeMolecules()
        {
            List<Molecule> molecules = new List<Molecule>();
            
            lock (container)
            {
                foreach (Molecule molecule in container)
                {
                    if (molecule.BelongsToFlake)
                    {
                        molecules.Add(molecule);
                    }
                }
            }
            return molecules;
        }*/

        #endregion

        #region IEnumerable<Molecule> Members

        public IEnumerator<Molecule> GetEnumerator()
        {
            return (IEnumerator<Molecule>)container.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
