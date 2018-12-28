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
            int lastStarted = GetLastStarted(list);
            string startedLine;
            if (lastStarted > -1)
            {
                startedLine = list[lastStarted].ToString();
                string[] startArray = startedLine.Split(' ');
                string[] dateTimeArray = ExtractDateTime(startArray);
            }
        }

        private string[] ExtractDateTime(string[] startArray)
        {
            string[] target = new string[startArray.Length - 1];
            for (int word = 1; word < startArray.Length; word++) target[word - 1] = startArray[word];
            return target;
        }

        private int GetLastStarted(List<String> list)
        {
            string ls;
            for (int line = list.Count() - 1; line > -1; line--)
            {
                ls = list[line].ToString();
                if (ls.Contains("Started")) return line;
            }
            return -1;
        }

        private List<String> GetListOfLines()
        {
            List<String> stringList = new List<String>();
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null) stringList.Add(line);
            }
            return stringList;
        }
    }
}
