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
            env = new Habitat( 1, 0, 0);
            growthSimulation = new GrowthSimulation(env.Presenter);
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
