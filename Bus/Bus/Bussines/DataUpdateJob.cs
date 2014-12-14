using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Bus.Models.UpdaterModels;
using System.Reflection;
using System.Text;

namespace Bus.Bussines
{
    public class DataUpdateJob
    {
        
        private char Separator = ',';
        private char StationSeparator = '-';
        private char MinuteSeparator = ' ';

        private int stationNumber = 0;
        private string previoslyName = "";

        public bool Update()
        {
            string[] dllFilenames = System.IO.Directory.GetFiles("C:/f", "*.csv");
            foreach (string filename in dllFilenames)
            {
                StreamReader sr = new StreamReader(filename, Encoding.Default);
                List<string> f = new List<string>();
                while (!sr.EndOfStream)
                {
                    f.Add(sr.ReadLine());
                }
                sr.Close();
                Update(f.ToArray());
            }
            return true;
        }

        private string[] GetFile(string path)
        {
            return null;
        }

        private string[] GetPathFiles()
        {
            return null;
        }

        private string Update(string[] file)
        {
            BusInStation.DayType type;            
            int skip = 0;
            int start = 0;
            while (skip < file.Length - 1)
            {          
                int skipLenght = GetSkipLenght(file, start, out type);
                start += skipLenght;
                var bis = Parse(file.Skip(skip).Take(skipLenght).ToArray(), skipLenght, type);
                BaseConnector.SetData(bis);
                skip += skipLenght;
            }
            return "Complete";
        }

        private int GetSkipLenght(string[] file, int start, out BusInStation.DayType type)
        {
            int count = 0;
            int arrow = start;
            int add = 0;
            type = BusInStation.DayType.allDays;
            while (true)
            {
                arrow++;
                count++;
                if (file[count].Contains(",воскр,"))
                {
                    type = BusInStation.DayType.twoFreeDay;
                    //return count+1;
                }
                if (file[count].Contains(",по вых.,"))
                {
                    type = BusInStation.DayType.freeDay;
                    //return count+1;
                }
                if (file[count].Contains(",ежедневно,"))
                {
                    type = BusInStation.DayType.allDays;
                    //return count+1;
                }
                if (arrow == file.Length - 1) add = 1;
                if (file[arrow][0] == 'A' || arrow == file.Length-1) return count+add;
            }
        }

        private BusInStation Parse(string[] stationInformation, int skipLenght, BusInStation.DayType type)
        {
            string stationName = stationInformation[0].Split(Separator)[4];
            string BusNumber = string.Empty;
             
            BusNumber = stationInformation[2].Split(Separator)[0];

            string BusName = stationInformation[2].Split(Separator)[1];

            if (BusName != previoslyName)
            {
                previoslyName = BusName;
                stationNumber = 0;
            }

            List<string> path = new List<string>();
            foreach (string currentStationName in stationInformation[3].Split(Separator)[1].Split(StationSeparator))
            {
                path.Add(currentStationName);
            }

            Dictionary<int, List<int>> timeWorkDays = null;// = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> timeFreeDays = null;// = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> TimeSunday = null;// = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> TimeSaturday = null;// = new Dictionary<int, List<int>>();
            int start = 4;
            int end = 4;
            if (type == BusInStation.DayType.freeDay)
            {
                timeWorkDays = GetTime(stationInformation, ref start, ref end);
                start = end;
                timeFreeDays = GetTime(stationInformation, ref start, ref end);
            }
            if (type == BusInStation.DayType.allDays)
            {
                timeWorkDays = GetTime(stationInformation, ref start, ref end);
            }
            if (type == BusInStation.DayType.twoFreeDay)
            {
                timeWorkDays = GetTime(stationInformation, ref start, ref end);
                start = end;
                TimeSaturday = GetTime(stationInformation, ref start, ref end);
                start = end;
                TimeSunday = GetTime(stationInformation, ref start, ref end);
            }
            stationNumber++;
            return new BusInStation() { BusNumber = BusNumber, BusName = BusName, StationName = stationName, TimeFreeDays = timeFreeDays, TimeWorkDays = timeWorkDays, TimeSaturday = TimeSaturday, TimeSunday = TimeSunday, DayTypeField = type, StationNumber = stationNumber };
        }

        private Dictionary<int, List<int>> GetTime(string[] stationInformation, ref int start, ref int end)
        {
            Dictionary<int, List<int>> time = new Dictionary<int, List<int>>();
            for (int i = start + 1; i < stationInformation.Length; i++)
            {
                if (stationInformation[i].Contains("по вых.") ||
                    stationInformation[i].Contains("субб") ||
                    stationInformation[i].Contains("воскр") ||
                    i == stationInformation.Length-1)
                {
                    if (i == stationInformation.Length - 1){
                    end = i;
                    }else{end = i-1;}
                    break;
                }
            }
            for (int i = start; i <= end; i++)
            {
                    int arrow = 4;
                    int jj = 0;
                    foreach (string minutes in stationInformation[i].Split(Separator))
                    {
                        if (!time.ContainsKey(arrow))
                        {
                            time.Add(arrow, new List<int>());
                        }
                        if (jj > 0 && jj < 20)
                            foreach (string m in minutes.Split(MinuteSeparator))
                            {
                                if (m != "")
                                    time[arrow].Add(int.Parse(m));
                            }
                        jj++;
                        arrow++;
                    }
            }
            return time;
        }
    }
}