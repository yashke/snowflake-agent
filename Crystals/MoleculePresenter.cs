using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Crystals
{
    public class MoleculePresenter
    {
        private Molecule molecule;
        private Point point;

        public MoleculePresenter(Molecule m)
        {
            molecule = m;
        }

        public void Draw(Pen pen, Graphics graphics)
        {
            for (int i = 0; i < 3; i++)
            {
                Molecule m = molecule.Neigbours[i];
                if (m != null)
                {
                    graphics.DrawLine(pen, this.Point(), m.Presenter.Point());
                }
            }
        }

        public Point Point()
        {
            if (point == null)
            {
                int x = (int)molecule.Position.X + 150;
                int y = (int)molecule.Position.Y + 150;
                point = new Point(x, y);
            }
            return point;
        }
    }
}
