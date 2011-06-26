using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Crystals;

namespace SnowCrystals
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static DensityBarController densityBarController;
        private static SpeedBarController speedBarController;
        private static GrowthSimulation growthSimulation;
        private static MainPanelController mainPanelController;
        private static Habitat env;

        [STAThread]
        static void Main()
        {
            double radius = 300, temperature = 10, density = 0.002;
            float scale = (float)0.5;
            double Desire = 0.55;
            double DesireRadius = Molecule.RADIUS * 7;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            growthSimulation = new GrowthSimulation((int)radius, scale);
            env = new Habitat(radius, temperature, density, growthSimulation.Center.X, growthSimulation.Center.Y, Desire, DesireRadius);
            densityBarController = new DensityBarController(growthSimulation, env);
            densityBarController.BindListeners();
            speedBarController = new SpeedBarController(growthSimulation, env);
            speedBarController.BindListeners();
            mainPanelController = new MainPanelController(growthSimulation, env);
            
            env.ThreadStart();

            Application.Run(growthSimulation);
        }
    }
}
