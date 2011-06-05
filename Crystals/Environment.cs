using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Crystals
{
    public class Habitat
    {
        public Logger Logger { get; set; }
        public Double Speed { get; set; }
        public Double Density { get; set; }
        public Double Volume { get; private set; }
        public UInt32 MoleculeCount { get { return (UInt32)(Density * Volume); } }

        public Double Density_Current { get; private set; }
        public UInt32 MoleculeCount_Current { get { return (UInt32)(Density_Current * Volume); } }

        public Position CondensationCenter { get; private set; }
        public Double Width { get; private set; }
        public Double Height { get; private set; }
      
        List<Molecule> Molecules;

        public Habitat(double width, double height, double speed, double density)
        {
            CondensationCenter = new Position(width / 2, height / 2, new V(0, 0));
            Molecules = new List<Molecule>();
            this.Speed = speed;
            this.Density = density;
            this.Volume = width * height;
            this.Density_Current = density;
            Logger = new Logger();
        }

        public void Start()
        {
            for (int i = 0; i < MoleculeCount; i++)
            {
                Molecule molecule = new Molecule(this);

                Molecules.Add(molecule);

                molecule.Thread = new Thread(new ParameterizedThreadStart(molecule.Appear));

                molecule.Thread.Start(Position.NextRandomPosition(Width, Height, Speed));
            }

            foreach (Molecule molelule in Molecules)
            {
                molelule.Thread.Join();
            }
        }

     }
}
