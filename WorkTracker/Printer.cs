using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker
{
    public static class Printer
    {

        internal static string StartTime(DateTime dt)
        {
            string month = dt.Month.ToString();
            string message = $"You began working at \n{dt.ToString("f")}.";
            return message;
        }

        internal static string StopTime(DateTime dt)
        {
            StringBuilder sb = new StringBuilder();
            string message = $"You stopped working at \n{dt.ToString("f")}.";
            //sb.Append(message);
            //message = $"\nThis took {dt.}"
            return message;
        }
    }
}
