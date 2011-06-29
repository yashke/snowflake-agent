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
            float radius = 200, temperature = 10, density = (float)0.01;
            float scale = (float)1;
            float Desire = 1;
            float DesireRadiusScale = 10;
            double DesireRadius = Molecule.RADIUS * DesireRadiusScale;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            growthSimulation = new GrowthSimulation((int)radius, scale, Desire, DesireRadiusScale, density);
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
