using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Crystals
{
    public class MoleculePresenter
    {
        public static int counter = 0;
        public Molecule molecule;
     
        public MoleculePresenter(Molecule m)
        {
            molecule = m;
            int x = (int)Math.Round(molecule.Position.X, 0) + 150;
            int y = (int)Math.Round(molecule.Position.Y, 0) + 150;
            Point = new Point(x, y);

        }

        public void Draw(Pen pen, Graphics graphics)
        {
            for (int i = 0; i < 3; i++)
            {
                Molecule m = molecule.Neigbours[i];
                if (m != null)
                {
                    graphics.DrawLine(pen, this.Point, m.Presenter.Point);
                }
            }
        }


        public Point Point
        {
            get;
            private set;
        }
    }
}
