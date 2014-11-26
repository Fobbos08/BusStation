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
        
        public static bool SetData(BusInStation currentData)//some parametrs
        {
             BusBaseDataDataContext _dataContext = new BusBaseDataDataContext();
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
                    _station = new LINQtoSQL.Station() { Name = currentData.StationName };
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
    }
}