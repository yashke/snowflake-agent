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

        private Point point;
     
        public MoleculePresenter(Molecule m)
        {
            molecule = m;
            point = new Point(0, 0);
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

        public void DrawPoint(Pen pen, Graphics graphics)
        {
            graphics.DrawEllipse(pen, this.Point.X, this.Point.Y, 1, 1);
        }


        public Point Point
        {
            get
            {
                point.X = (int)Math.Round(molecule.Position.X, 0);
                point.Y = (int)Math.Round(molecule.Position.Y, 0);
                return point;
            }
        }
    }
}
