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
        private static Crystals.Environment env;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            env = new Crystals.Environment(0, 0, 0);
            growthSimulation = new GrowthSimulation();
            densityBarController = new DensityBarController(growthSimulation, env);
            densityBarController.BindListeners();
            speedBarController = new SpeedBarController(growthSimulation, env);
            speedBarController.BindListeners();
            Application.Run(growthSimulation);
        }
    }
}
