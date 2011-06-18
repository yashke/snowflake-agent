using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Crystals
{
    public interface MoleculeAttachedListener
    {
        void MoleculeAttached(Point attached, List<Point> linked);
    }
}
