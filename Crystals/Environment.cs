﻿using System;
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

        public Habitat(double radius, double temperature, double density)
        {
            CondensationCenter = new Molecule(this, true);
            this.Temperature = temperature;
            this.Density = density;
            this.Volume = Math.PI * radius * radius;
            this.Density_Current = density;
            this.Radius = radius;
            Logger = new Logger();
            Molecules = new MoleculeContainer(this);
            NewBindingListeners = new List<NewBindingListener>();

            Thread = new Thread(new ThreadStart(this.Start));
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
            Molecules.Add(CondensationCenter);
            for (int i = 0; i < MoleculeCount; i++)
            {
                var molecule = new Molecule(this);
                Molecules.Add(molecule);
            }

            while (Opened)
            {
                foreach (Molecule molecule in Molecules)
                {
                    molecule.Cycle();
                }
                Thread.Sleep(100);
            }
        }

        public Molecule GetMoveInterferer(Molecule molecule)
        {
           return Molecules.GetMoveInterferer(molecule);

        }

        public void AddNewBindingListener(NewBindingListener listener)
        {
            NewBindingListeners.Add(listener);
        }

        public void FireNewBinding()
        {
            foreach (NewBindingListener listener in NewBindingListeners)
            {
                listener.NewBinding(FlakeMolecules());
            }
        }

        public List<Molecule> FlakeMolecules()
        {
            return Molecules.FlakeMolecules();
        }
    }
}
