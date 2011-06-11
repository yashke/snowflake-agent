using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    public class MoleculeContainer : ICollection<Molecule>
    {
        public Molecule GetMoveInterferer(Molecule molecule)
        {
            throw new NotImplementedException();
        }

        #region ICollection<Molecule> Members

        public void Add(Molecule item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Molecule item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Molecule[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Molecule item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<Molecule> Members

        public IEnumerator<Molecule> GetEnumerator()
        {
            throw new NotImplementedException();
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
