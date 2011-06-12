﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    public class MoleculeContainer : ICollection<Molecule>
    {
        public List<Molecule> container;

        public MoleculeContainer()
        {
            container = new List<Molecule>();
        }

        public Molecule GetMoveInterferer(Molecule molecule)
        {
            Molecule found = null;
            foreach (Molecule mol in container)
            {
                if (mol != molecule && molecule.IsNear(mol))
                {
                    
                }
            }
            return found;
        }

        #region ICollection<Molecule> Members

        public void Add(Molecule item)
        {
            container.Add(item);
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
            return container.Remove(item);
        }

        public void ChangePosition(Molecule molecule, double x, double y)
        {

        }

        #endregion

        #region IEnumerable<Molecule> Members

        public IEnumerator<Molecule> GetEnumerator()
        {
            return container.GetEnumerator();
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
