using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    public class Logger
    {
        public Logger()
        {

        }
        public void Log(object o)
        {
            if (o == "ATTACHED" || o == "TRY")
            Console.WriteLine(String.Format("{0}", o));
        }
        public void Log1(object o)
        {
                Console.WriteLine(String.Format("{0}", o));
        }
    }
}
