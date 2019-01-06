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
        }

        public string StartTime(DateTime dt, string path)
        {
            string month = dt.Month.ToString();
            string message = $"You began working at \n{dt.ToString("f")}.";
            using (StreamWriter sw = new StreamWriter(path, true))
                sw.WriteLine("Started: " + dt.ToString("f"));

            return message;
        }

        public string StopTime(DateTime dt, string path)
        {
            string message = $"You stopped working at \n{dt.ToString("f")}.";
            using (StreamWriter sw = new StreamWriter(path, true))
                sw.WriteLine("Stopped: " + dt.ToString("f"));

            return message;
        }

        internal string TimeWorked()
        {
            Analyzer an = new Analyzer(path);
            string output = an.GetElapsedTimeAsString();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(output);
                sw.WriteLine();
            }

            return output;
        }
    }
}
