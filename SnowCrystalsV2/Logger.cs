using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SnowCrystals
{
    public class Logger
    {
        static StreamWriter sw;

        public static void StartLog()
        {
            if (!Directory.Exists("logs/"))
                Directory.CreateDirectory("logs/");
            sw = File.CreateText(String.Format("logs/{0:yyyy-MM-dd HH-mm-ss} log.html", DateTime.Now));
            sw.Write("<table><tr><td colspan='2'>Log created");

        }

        public static void Log(string message)
        {
            sw.Write("<tr><td colspan='2'>");
            sw.Write(message);
        }

        public static void Log(object source, object tolog)
        {
            sw.Write(String.Format("<tr><td>{0}<td>{1}", source, tolog));
        }

        public static void EndLog()
        {
            sw.Close();
        }
    }
}
