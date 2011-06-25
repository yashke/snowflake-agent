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
            Crystals.Habitat environment = new Crystals.Habitat(150, 10, 0.01, 150, 150);
            
            environment.ThreadStart();

            //3.14*80*80*0.01
        }
    }
}
