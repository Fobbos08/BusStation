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
             
            //var bus = _dataContext.Bus.Where(x => x.Name == currentData.BusName).Select(x => x);
            var buses = from bus in _dataContext.Bus
                      where currentData.BusName == bus.Name &&
                      currentData.BusNumber.ToString() == bus.Code
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
                    _bus = new LINQtoSQL.Bus() { Code = currentData.BusNumber.ToString(), Name = currentData.BusName };
                    _dataContext.Bus.InsertOnSubmit(_bus);
                    _dataContext.SubmitChanges();
                }
            }
            else
            {
                _bus = new LINQtoSQL.Bus() { Code = currentData.BusNumber.ToString(), Name = currentData.BusName };
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
                    Bus.Bussines.LINQtoSQL.Time time = new Time() { FreeDay = "false", Hour = a.Key.ToString(), Minute = b.ToString() };
                    _dataContext.Times.InsertOnSubmit(time);
                    _dataContext.SubmitChanges();
                    Bus.Bussines.LINQtoSQL.BusPathToTime bpt = new BusPathToTime() { Time_ID = time.ID, BusPath_ID = _busPath.ID };
                    _dataContext.BusPathToTimes.InsertOnSubmit(bpt);
                    _dataContext.SubmitChanges();
                }
            }

            foreach (var a in currentData.TimeFreeDays)
            {
                foreach (var b in a.Value)
                {
                    Bus.Bussines.LINQtoSQL.Time time = new Time() { FreeDay = "true", Hour = a.Key.ToString(), Minute = b.ToString() };
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

        public static List<Station> GetStations()
        {
            List<Station> stations = new List<Station>();
            var stationsId = from value in _dataContext.BusPaths
                             select value.Station_ID;
            foreach (var value in stationsId)
            {
                var station = GetStation(value);
                stations.Add(station);
            }
            return stations;
        }
    }
}