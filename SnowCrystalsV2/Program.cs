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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            growthSimulation = new GrowthSimulation();
            env = new Habitat(150, 10, 0.02, growthSimulation.Center.X, growthSimulation.Center.Y);
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
