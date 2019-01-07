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

        public string GetTimeElapsedThisSessionAsString()
        {
            int elapsedMinutesThisSession = GetElapsedMinutesThisSession();
            int elapsedHoursThisSession = elapsedMinutesThisSession / 60;
            elapsedMinutesThisSession %= 60;

            return $"Work lasted {elapsedHoursThisSession} hour(s) and {elapsedMinutesThisSession} minute(s).";
        }

        public string GetTimeElapsedThisMonthAsString()
        {

            int[] hoursAndMinutesArray = GetElapsedHoursAndMinutes();

            hoursAndMinutesArray = ConsolidateHoursAndMinutes(hoursAndMinutesArray);

            return $"Total work this month: {hoursAndMinutesArray[0]} hour(s) and {hoursAndMinutesArray[1]} minute(s).";
        }

        private int[] ConsolidateHoursAndMinutes(int[] hoursAndMinutesArray)
        {
            if (hoursAndMinutesArray[1] >= 60)
            {
                hoursAndMinutesArray[0] += hoursAndMinutesArray[1] / 60;
                hoursAndMinutesArray[1] = hoursAndMinutesArray[1] % 60;
            }
            return hoursAndMinutesArray;
        }

        private int[] GetElapsedHoursAndMinutes()
        {
            List<string> text = GetListOfLines();
            int minutes = 0;
            int hours = 0;

            foreach (string line in text)
            {
                if (line.Contains("Work"))
                {
                    string[] lineArray = line.Split(' ');
                    if (int.TryParse(lineArray[2], out int hoursFound)) hours += hoursFound;
                    if (int.TryParse(lineArray[5], out int minutesFound)) minutes += minutesFound;
                }
            }

            int[] output = new int[2];
            output[0] = hours;
            output[1] = minutes;
            return output;
        }

        private int GetElapsedMinutesThisSession()
        {
            string[] StartTimeStringArray = GetTimeRecorded(true);
            string[] StopTimeStringArray = GetTimeRecorded(false);

            int[] StartTimeIntArray = GetHourAndMinute(StartTimeStringArray);
            string startAMorPM = StartTimeStringArray[2];

            int[] EndTimeIntArray = GetHourAndMinute(StopTimeStringArray);
            string endAMorPM = StopTimeStringArray[2];

            int startTimeInMinutes = GetTimeInMinutes(StartTimeIntArray[0], StartTimeIntArray[1], startAMorPM);
            int endTimeInMinutes = GetTimeInMinutes(EndTimeIntArray[0], EndTimeIntArray[1], endAMorPM);

            int hoursInDay = 24;
            int minutesInHour = 60;
            if (endTimeInMinutes < startTimeInMinutes) endTimeInMinutes += hoursInDay * minutesInHour;

            return endTimeInMinutes - startTimeInMinutes;
        }

        private int[] GetHourAndMinute(string[] source)
        {
            int[] result = new int[2];
            if (int.TryParse(source[0], out int hours)) result[0] = hours;
            if (int.TryParse(source[1], out int minutes)) result[1] = minutes;
            return result;
        }

        private int GetTimeInMinutes(int hours, int minutes, string period)
        {
            int minutesInHour = 60;
            if (hours == 12) hours = 0;
            if (period.Equals("PM")) hours += 12;
            return (hours * minutesInHour) + minutes;
        }

        private string[] GetTimeRecorded(bool start)
        {
            List<String> list = GetListOfLines();
            int targetLine = GetLastStarted(list, start);
            string splitTargetLine;
            string[] time = new string[3];
            if (targetLine > -1)
            {
                splitTargetLine = list[targetLine].ToString();
                string[] startArray = splitTargetLine.Split(' ');
                string[] hour = startArray[5].Split(':');
                time[0] = hour[0];
                time[1] = hour[1];
                time[2] = startArray[6];
            }
            return time;
        }

        private int GetLastStarted(List<String> list, bool start)
        {
            string ls;
            for (int line = list.Count() - 1; line > -1; line--)
            {
                ls = list[line].ToString();
                if (start && ls.Contains("Started")) return line;
                if (!start && ls.Contains("Stopped")) return line;
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
