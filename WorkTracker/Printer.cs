using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker
{
    public class Printer
    {
        StreamWriter sw;
        string path;

        public Printer(string path)
        {
            this.path = path;
            FileStream fappend = new FileStream(path, FileMode.Append);
            sw = new StreamWriter(fappend);
        }

        internal string StartTime(DateTime dt, string path)
        {
            string month = dt.Month.ToString();
            string message = $"You began working at \n{dt.ToString("f")}.";
            sw.WriteLine("Started: " + dt.ToString("f"));
            sw.Close();
            return message;
        }

        internal string StopTime(DateTime dt, string path)
        {
            //StringBuilder sb = new StringBuilder();
            string message = $"You stopped working at \n{dt.ToString("f")}.";
            sw.WriteLine("Stopped: " + dt.ToString("f"));
            sw.WriteLine();
            sw.Close();
            //sb.Append(message);
            //message = $"\nThis took {dt.}"
            return message;
        }
    }
}
