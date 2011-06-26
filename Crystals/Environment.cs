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

        public Molecule CondensationCenter { get; private set; }
        public Double Radius { get; private set; }

        public bool Opened = true;

        private HabitatPresenter presenter;
        public HabitatPresenter Presenter
        {
            get
            {
                if (presenter == null)
                {
                    presenter = new HabitatPresenter(this);
                }
                return presenter;
            }
        }

        public List<NewBindingListener> NewBindingListeners;

        public MoleculeContainer Molecules;

        Thread Thread;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius">in angstroems (1e(-10)mm)</param>
        /// <param name="temperature"></param>
        /// <param name="density"></param>

        public Habitat(double radius, double temperature, double density, double centerX, double centerY )
        {
            this.Temperature = temperature;
            this.Density = density;
            this.Volume = Math.PI * radius * radius;
            this.Density_Current = density;
            this.Radius = radius;
            Logger = new Logger();
         
            NewBindingListeners = new List<NewBindingListener>();

            Molecules = new MoleculeContainer(this);

            this.CondensationCenter = new Molecule(this, true);
            this.CondensationCenter.Position.X = centerX;
            this.CondensationCenter.Position.Y = centerY;
            Molecules.Add(CondensationCenter);
           
            Thread = new Thread(new ThreadStart(this.Start));
        }

        void CreateCondensationCenter()
        {
            Molecule mTo = CondensationCenter, mAttach;
            foreach (var angle in new double[] { Math.PI * 5 / 6, Math.PI, 3 * Math.PI / 2, 3 * Math.PI / 2, 11 * Math.PI / 6 })
            {
                mAttach = new Molecule(this);
                mAttach.Position = mTo.Position.PointOfAngle(Molecule.TETRAHEDRON_SITE, angle);
                Molecules.Add(mAttach);
                mAttach.TryToAttachDefinitely(mTo); 
                mTo = mAttach;
            }
        }

        public void ThreadStart()
        {
            Thread.Start();
        }

        public void ThreadStop()
        {
            Opened = false;
        }

        public void Start()
        {
            CreateCondensationCenter();

            for (int i = 0; i < MoleculeCount; i++)
            {
                CreateMolecule();
            }
            while (Opened)
            {
                for(int i = 0; i<Molecules.Count; i++)
                    Molecules[i].Cycle();
            }
        }

        public void CreateMolecule()
        {
            Molecules.Add(new Molecule(this));
        }

        public Molecule GetMoveInterferer(Molecule molecule)
        {
           return Molecules.GetMoveInterferer(molecule);

        }

        public void AddNewBindingListener(NewBindingListener listener)
        {
            NewBindingListeners.Add(listener);
        }

        public void FireNewBinding(Molecule molecule)
        {
            foreach (NewBindingListener listener in NewBindingListeners)
            {
                listener.NewBinding(molecule);
            }
            CreateMolecule();
        }

       /* public List<Molecule> FlakeMolecules()
        {
            return Molecules.FlakeMolecules();
        }*/
    }
}
