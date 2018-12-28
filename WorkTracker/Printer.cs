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
        string path;

        public Printer(string path)
        {
            this.path = path;
            FileStream fappend = new FileStream(path, FileMode.Append);
        }

        public string StartTime(DateTime dt, string path)
        {
            string month = dt.Month.ToString();
            string message = $"You began working at \n{dt.ToString("f")}.";
            using (StreamWriter sw = new StreamWriter(path, true))
                sw.WriteLine("Started: " + dt.ToString("f"));
            return message;
        }

        internal string StopTime(DateTime dt, string path)
        {
            //StringBuilder sb = new StringBuilder();
            string message = $"You stopped working at \n{dt.ToString("f")}.";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("Stopped: " + dt.ToString("f"));
                sw.WriteLine();
            }
            //sb.Append(message);
            //message = $"\nThis took {dt.}"
            return message;
        }
    }
}
