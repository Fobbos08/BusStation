using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bus.Models.UpdaterModels;
using Bus.Bussines.LINQtoSQL;

namespace Bus.Bussines
{

    public static class BaseConnector
    {
        private static BusBaseDataDataContext _dataContext = new BusBaseDataDataContext();

        public static bool SetData(BusInStation currentData)//some parametrs
        {
           var buses = from bus in _dataContext.Bus
                      where currentData.BusName == bus.Name &&
                      currentData.BusNumber == bus.Code
                      select bus;
            Bus.Bussines.LINQtoSQL.Bus _bus;
            if (buses != null)
            {
                if (buses.ToList().Count > 0)
                {
                    _bus = buses.ToList()[0];
                }
                else
                {
                    _bus = new LINQtoSQL.Bus() { Code = currentData.BusNumber, Name = currentData.BusName };
                    _dataContext.Bus.InsertOnSubmit(_bus);
                    _dataContext.SubmitChanges();
                }
            }
            else
            {
                _bus = new LINQtoSQL.Bus() { Code = currentData.BusNumber, Name = currentData.BusName };
                _dataContext.Bus.InsertOnSubmit(_bus);
                _dataContext.SubmitChanges();
            }


            Bus.Bussines.LINQtoSQL.Station _station;
            var stations = from station in _dataContext.Stations
                        where currentData.StationName == station.Name
                           select station;
            if (stations != null)
            {
                if (stations.ToList().Count > 0)
                {
                    _station = stations.ToList()[0];
                }
                else
                {
                    _station = new LINQtoSQL.Station() { Name = currentData.StationName, Position="" };
                    _dataContext.Stations.InsertOnSubmit(_station);
                    _dataContext.SubmitChanges();
                }
            }
            else
            {
                _station = new LINQtoSQL.Station() { Name = currentData.StationName };
                _dataContext.Stations.InsertOnSubmit(_station);
                _dataContext.SubmitChanges();
            }

            //create only
            Bus.Bussines.LINQtoSQL.BusPath _busPath = new BusPath() {Bus_ID = _bus.ID, Station_ID = _station.ID, StationNumber = currentData.StationNumber.ToString() };
            _dataContext.BusPaths.InsertOnSubmit(_busPath);
            _dataContext.SubmitChanges();

            
            foreach (var a in currentData.TimeWorkDays)
            {
                foreach(var b in a.Value)
                {
                    Bus.Bussines.LINQtoSQL.Time time = new Time() { TypeDay = "WorkDay", Hour = a.Key.ToString(), Minute = b.ToString() };
                    _dataContext.Times.InsertOnSubmit(time);
                    _dataContext.SubmitChanges();
                    Bus.Bussines.LINQtoSQL.BusPathToTime bpt = new BusPathToTime() { Time_ID = time.ID, BusPath_ID = _busPath.ID };
                    _dataContext.BusPathToTimes.InsertOnSubmit(bpt);
                    _dataContext.SubmitChanges();
                }
            }
            if (currentData.TimeFreeDays != null)
            foreach (var a in currentData.TimeFreeDays)
            {
                foreach (var b in a.Value)
                {
                    Bus.Bussines.LINQtoSQL.Time time = new Time() { TypeDay = "FreeDay", Hour = a.Key.ToString(), Minute = b.ToString() };
                    _dataContext.Times.InsertOnSubmit(time);
                    _dataContext.SubmitChanges();
                    Bus.Bussines.LINQtoSQL.BusPathToTime bpt = new BusPathToTime() { Time_ID = time.ID, BusPath_ID = _busPath.ID };
                    _dataContext.BusPathToTimes.InsertOnSubmit(bpt);
                    _dataContext.SubmitChanges();
                }
            }
            if (currentData.TimeSaturday != null)
            foreach (var a in currentData.TimeSaturday)
            {
                foreach (var b in a.Value)
                {
                    Bus.Bussines.LINQtoSQL.Time time = new Time() { TypeDay = "Saturday", Hour = a.Key.ToString(), Minute = b.ToString() };
                    _dataContext.Times.InsertOnSubmit(time);
                    _dataContext.SubmitChanges();
                    Bus.Bussines.LINQtoSQL.BusPathToTime bpt = new BusPathToTime() { Time_ID = time.ID, BusPath_ID = _busPath.ID };
                    _dataContext.BusPathToTimes.InsertOnSubmit(bpt);
                    _dataContext.SubmitChanges();
                }
            }
            if (currentData.TimeSunday != null)
            foreach (var a in currentData.TimeSunday)
            {
                foreach (var b in a.Value)
                {
                    Bus.Bussines.LINQtoSQL.Time time = new Time() { TypeDay = "Sunday", Hour = a.Key.ToString(), Minute = b.ToString() };
                    _dataContext.Times.InsertOnSubmit(time);
                    _dataContext.SubmitChanges();
                    Bus.Bussines.LINQtoSQL.BusPathToTime bpt = new BusPathToTime() { Time_ID = time.ID, BusPath_ID = _busPath.ID };
                    _dataContext.BusPathToTimes.InsertOnSubmit(bpt);
                    _dataContext.SubmitChanges();
                }
            }
            return true;
        }

        public static List<LINQtoSQL.Bus> GetBusesFromStation(string stationName)
        {
            var paths = GetBusPath(GetStation(stationName));
            List<LINQtoSQL.Bus> buses = new List<LINQtoSQL.Bus>();
            foreach (var path in paths)
            {
                var bus = GetBus(path.Bus_ID);
                if (!buses.Contains(bus))
                    buses.Add(bus);
            }
            return buses;
        }

        public static LINQtoSQL.Bus GetBus(int id)
        {
            var buses = from bus in _dataContext.Bus
                        where bus.ID == id
                        select bus;
            var bList = buses.ToList();
            if (bList.Count != 0)
            {
                return buses.ToList()[0];
            }
            return null;
        }

        public static List<LINQtoSQL.Bus> GetBuses()
        {
            var buses = from bus in _dataContext.Bus
                        select bus;
            if (buses != null)
            {
                try
                {
                    return buses.ToList();
                }catch(Exception ee)
                {}
            }
            return null;
        }

        public static List<LINQtoSQL.Bus> GetBuses(int stationId)
        {
            List<Bus.Bussines.LINQtoSQL.Bus> buses = new List<Bus.Bussines.LINQtoSQL.Bus>();
            var busesId = from value in _dataContext.BusPaths
                             where value.Station_ID == stationId
                             select value.Bus_ID;
            foreach (var value in busesId)
            {
                var bus = GetBus(value);
                buses.Add(bus);
            }
            return buses;
        }

        private static List<BusPath> GetBusPath(Station station)
        {
            var busPaths = from busPath in _dataContext.BusPaths
                           where busPath.Station_ID == station.ID
                           select busPath;
            return busPaths.ToList();
        }

        private static List<BusPath> GetBusPath(LINQtoSQL.Bus bus)
        {
            var busPaths = from busPath in _dataContext.BusPaths
                           where busPath.Station_ID == bus.ID
                           select busPath;
            return busPaths.ToList();
        }

        public static Station GetStation(string stationName)
        {
            var stations = from station in _dataContext.Stations
                          where station.Name.ToLower() == stationName.ToLower()
                          select station;
            var stationsList = stations.ToList();
            if (stationsList != null)
            if (stationsList.Count != 0)
                return stationsList[0];
            return null;
        }

        public static Station GetStation(int stationId)
        {
            var stations = from station in _dataContext.Stations
                           where station.ID == stationId
                           select station;
            var stationsList = stations.ToList();
            if (stationsList != null)
                if (stationsList.Count != 0)
                    return stationsList[0];
            return null;
        }

        public static List<Station> GetStations(int BusId)
        {
            List<Station> stations = new List<Station>();
            var stationsId = from value in _dataContext.BusPaths
                             where value.Bus_ID == BusId
                             select value.Station_ID;
            foreach (var value in stationsId)
            {
                var station = GetStation(value);
                stations.Add(station);
            }
            return stations;
        }

        public static List<Station> GetOrderStations(int BusId)
        {
            List<Station> stations = new List<Station>();
            var path = from value in _dataContext.BusPaths
                             where value.Bus_ID == BusId
                             select value;
            //path = path.OrderBy(x => int.Parse(x.StationNumber));
            path.ToList().Sort((x, y) => int.Parse(x.StationNumber).CompareTo(int.Parse(y.StationNumber)));
            


            foreach (var value in path)
            {
                var station = GetStation(value.Station_ID);
                stations.Add(station);
            }
            return stations;
        }

        public static List<Station> GetStations()
        {
            List<Station> stations = new List<Station>();
            var stationsId = from value in _dataContext.BusPaths
                             select value.Station_ID;
            foreach (var value in stationsId)
            {
                var station = GetStation(value);
                if(!stations.Contains(station))
                    stations.Add(station);
            }
            return stations;
        }

        private static List<int> GetTimes(int stationId, int busId)
        {
            var pts = from value in _dataContext.BusPaths
                      where value.Bus_ID == busId && value.Station_ID == stationId
                      select value;
            var ptsl = pts.ToList();
            if (ptsl.Count > 0)
            {
                var ids = from value in _dataContext.BusPathToTimes
                          where ptsl[0].ID == value.BusPath_ID
                          select value.Time_ID;
                return ids.ToList();
            }
            return null;
        }

        private static Bus.Bussines.LINQtoSQL.Time GetTime(int id)
        {
            var times = from value in _dataContext.Times
                        where value.ID == id
                        select value;
            var timeList = times.ToList();
            if (timeList.Count > 0)
            {
                return timeList[0];
            }
            return null;
        }

        #region GetCurrentTimes
        public static Dictionary<int, List<int>> GetFreeTimes(int stationId, int busId)
        {
            var times = GetTimes(stationId, busId);
            Dictionary<int, List<int>> timeDictionary = new Dictionary<int, List<int>>();
            foreach (var time in times)
            {
                var currentTime = GetTime(time);
                if (currentTime != null)
                {
                    if (currentTime.TypeDay == "FreeDay")
                    {
                        if (!timeDictionary.ContainsKey(int.Parse(currentTime.Hour)))
                        {
                            timeDictionary.Add(int.Parse(currentTime.Hour), new List<int>() { int.Parse(currentTime.Minute) });
                        }
                        else
                        {
                            timeDictionary[int.Parse(currentTime.Hour)].Add(int.Parse(currentTime.Minute));
                        }
                    }
                }
            }
            return timeDictionary;
        }
        public static Dictionary<int, List<int>> GetWorkTimes(int stationId, int busId)
        {
            var times = GetTimes(stationId, busId);
            Dictionary<int, List<int>> timeDictionary = new Dictionary<int, List<int>>();
            foreach (var time in times)
            {
                var currentTime = GetTime(time);
                if (currentTime != null)
                {
                    if (currentTime.TypeDay == "WorkDay")
                    {
                        if (!timeDictionary.ContainsKey(int.Parse(currentTime.Hour)))
                        {
                            timeDictionary.Add(int.Parse(currentTime.Hour), new List<int>() { int.Parse(currentTime.Minute) });
                        }
                        else
                        {
                            timeDictionary[int.Parse(currentTime.Hour)].Add(int.Parse(currentTime.Minute));
                        }
                    }
                }
            }
            return timeDictionary;
        }
        public static Dictionary<int, List<int>> GetSaturdayTimes(int stationId, int busId)
        {
            var times = GetTimes(stationId, busId);
            Dictionary<int, List<int>> timeDictionary = new Dictionary<int, List<int>>();
            foreach (var time in times)
            {
                var currentTime = GetTime(time);
                if (currentTime != null)
                {
                    if (currentTime.TypeDay == "Saturday")
                    {
                        if (!timeDictionary.ContainsKey(int.Parse(currentTime.Hour)))
                        {
                            timeDictionary.Add(int.Parse(currentTime.Hour), new List<int>() { int.Parse(currentTime.Minute) });
                        }
                        else
                        {
                            timeDictionary[int.Parse(currentTime.Hour)].Add(int.Parse(currentTime.Minute));
                        }
                    }
                }
            }
            return timeDictionary;
        }
        public static Dictionary<int, List<int>> GetSundayTimes(int stationId, int busId)
        {
            var times = GetTimes(stationId, busId);
            Dictionary<int, List<int>> timeDictionary = new Dictionary<int, List<int>>();
            foreach (var time in times)
            {
                var currentTime = GetTime(time);
                if (currentTime != null)
                {
                    if (currentTime.TypeDay == "Sunday")
                    {
                        if (!timeDictionary.ContainsKey(int.Parse(currentTime.Hour)))
                        {
                            timeDictionary.Add(int.Parse(currentTime.Hour), new List<int>() { int.Parse(currentTime.Minute) });
                        }
                        else
                        {
                            timeDictionary[int.Parse(currentTime.Hour)].Add(int.Parse(currentTime.Minute));
                        }
                    }
                }
            }
            return timeDictionary;
        }
        #endregion
    }
}