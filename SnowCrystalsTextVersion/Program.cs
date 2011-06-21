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
            Crystals.Habitat environment = new Crystals.Habitat(80, 10, 10);
            environment.ThreadStart();
        }
    }
}
