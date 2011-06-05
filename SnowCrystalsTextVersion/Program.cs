using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowCrystalsTextVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            Crystals.Habitat environment = new Crystals.Habitat(1, 1, 10, 10);
            environment.Start();
        }
    }
}
