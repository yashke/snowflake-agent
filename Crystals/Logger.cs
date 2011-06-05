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
            Console.WriteLine(String.Format("{0}", o));
        }
    }
}
