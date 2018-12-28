using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker
{
    class Analyzer
    {
        String path;

        public Analyzer(string path)
        {
            this.path = path;
        }

        internal string GetElapsedTime()
        {
            string TimeStarted = GetTimeStarted();
        }

        private string GetTimeStarted()
        {
            List<String> list = GetListOfLines();
        }

        private List<String> GetListOfLines()
        {
            List<String> stringList = new List<String>);
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null) stringList.Add(line);
            }
            return stringList;
        }
    }
}
