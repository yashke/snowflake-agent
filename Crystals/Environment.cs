using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Crystals
{
    public class Environment
    {
        public Double Speed { get; set; }
        public Double Density { get; set; }
        public Double Volume { get; private set; }
        public UInt32 MoleculeCount { get { return (UInt32)Density * Volume; } }

        public Double Density_Current { get; private set; }
        public UInt32 MoleculeCount_Current { get { return (UInt32)Density_Current * Volume; } }

        public Position CondensationCenter { get; private set; }
        public Double Radius { get; private set; }


        List<Molecule> Molecules;

        public Environment(double radius, double speed, double density)
        {
            CondensationCenter = new Position(0, 0, 0);
            Molecules = new List<Molecule>();
            this.Speed = speed;
            this.Density = density;
            this.Density_Current = 0;
        }

        public void Start()
        {
            for (int i = 0; i < MoleculeCount; i++)
            {
                Molecule molecule = new Molecule(this);
                
                Thread thread = Threads.Add(new Thread(new ParameterizedThreadStart(
            }
        }




    }
}
