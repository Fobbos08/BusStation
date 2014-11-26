using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Bus.Models.UpdaterModels;

namespace Bus.Bussines
{
    public class DataUpdateJob
    {
        private char Separator = ';';
        private char StationSeparator = '-';
        private char MinuteSeparator = ' ';

        private int stationNumber = 0;
        private string previoslyName = "";

        public bool Update()
        {
            StreamReader sr = new StreamReader("C:/f/q.csv");
            List<string> f = new List<string>();
            while(!sr.EndOfStream)
            {
                f.Add(sr.ReadLine());
            }
            Update(f.ToArray());
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
            int skip = 0;
            while (skip < file.Length - 1)
            {
                var bis = Parse(file.Skip(skip).Take(6).ToArray());
                BaseConnector.SetData(bis);
                skip += 6;

            }
            return "Complete";
        }

        private BusInStation Parse(string[] stationInformation)
        {
            string stationName = stationInformation[0].Split(Separator)[4];
            string[] hours = null;
            int BusNumber = 0;
            try
            {
                BusNumber = int.Parse(stationInformation[2].Split(Separator)[0]);
            }
            catch (Exception exception)
            {
                //return null;
            }

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

            Dictionary<int, List<int>> timeWorkDays = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> timeFreeDays = new Dictionary<int, List<int>>();
            int arrow = 5;
            foreach (string minutes in stationInformation[4].Split(Separator))
            {
                List<int> minutesList = new List<int>();
                int j = 0;
                if (j > 0 && j < 20)
                foreach (string m in minutes.Split(MinuteSeparator))
                {
                    
                    minutesList.Add(int.Parse(m));
                }
                j++;
                timeWorkDays.Add(arrow, minutesList);
                arrow++;
            }
            arrow = 5;
            foreach (string minutes in stationInformation[5].Split(Separator))
            {
                List<int> minutesList = new List<int>();
                int j = 0;
                if (j > 0 && j < 20)
                foreach (string m in minutes.Split(MinuteSeparator))
                {
                    minutesList.Add(int.Parse(m));
                }
                j++;
                timeFreeDays.Add(arrow, minutesList);
                arrow++;
            }
            stationNumber++;
            return new BusInStation() { BusNumber = BusNumber, BusName = BusName, StationName = stationName, TimeFreeDays = timeFreeDays, TimeWorkDays = timeWorkDays, StationNumber = stationNumber };
        }
    }
}