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

        /// <summary>
        /// [Celcius]
        /// </summary>
        public double Temperature { get; set; }
     
        public Double Density { get; set; }
        public Double Volume { get; private set; }
        public UInt32 MoleculeCount { get { return (UInt32)(Density * Volume); } }

        public Double Density_Current { get; private set; }
        public UInt32 MoleculeCount_Current { get { return (UInt32)(Density_Current * Volume); } }

        public Position CondensationCenter { get; private set; }
        public Double Radius { get; private set; }

        public MoleculeContainer Molecules;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius">in angstroems (1e(-10)mm)</param>
        /// <param name="temperature"></param>
        /// <param name="density"></param>

        public Habitat(double radius, double temperature, double density)
        {
            CondensationCenter = new Position(0, 0, new V(0, 0));
            this.Temperature = temperature;
            this.Density = density;
            this.Volume = Math.PI * radius * radius;
            this.Density_Current = density;
            this.Radius = radius;
            Logger = new Logger();
            Molecules = new MoleculeContainer();
        }

        public void Start()
        {
            for (int i = 0; i < MoleculeCount; i++)
            {
                var molecule = new Molecule(this);
                Molecules.Add(molecule);
            }

            while (true)
            {
                foreach (Molecule molecule in Molecules)
                {
                    molecule.Cycle();
                }
            }
        }

        public Molecule GetMoveInterferer(Molecule molecule)
        {
           return Molecules.GetMoveInterferer(molecule);

        }

        public void ChangeMoleculePosition(Molecule molecule, double x, double y)
        {
            Molecules.ChangePosition(molecule, x, y);
        }
    }
}
