using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WorkTracker
{
    public class Printer
    {
        public string path;
        string job;

        public Printer(string path, string job)
        {
            this.path = path;
            this.job = job;
            DateTime dt = DateTime.Now;
            string currentMonth = dt.ToString("MMM");
            string currentYear = dt.Year.ToString();
            this.path += $"{this.job}_{currentYear}_{currentMonth}.txt";
        }

        public string StartTime(DateTime dt)
        {
            string month = dt.Month.ToString();
            string message = $"You began working at \n{dt.ToString("f")}.";
            using (StreamWriter sw = new StreamWriter(path, true))
                sw.WriteLine("Started: " + dt.ToString("f"));

            return message;
        }

        public string StopTime(DateTime dt)
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
