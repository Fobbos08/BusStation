using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bus.Models;
using Bus.Bussines;

namespace Bus.Helpers
{
    public static class PathPageHelper
    {
        private static Dictionary<int, List<int>> paths = new Dictionary<int, List<int>>();//busId, List<stationId>

        public static void Update()
        {
            paths.Clear();
            var buses = BaseConnector.GetBuses();
            foreach (var bus in buses)
            {
                paths.Add(bus.ID, new List<int>());
                var stations = BaseConnector.GetOrderStations(bus.ID);
                foreach (var station in stations)
                {
                    paths[bus.ID].Add(station.ID);
                }
            }
        }

        public static List<PathInformation> GetPath(string startStation, string endStation)
        {
            int startStationId = BaseConnector.GetStation(startStation).ID;
            int endStationId = BaseConnector.GetStation(endStation).ID;
            List<PathInformation> path = new List<PathInformation>();
            Update();
            bool stop = false;
            return Rec(startStationId, endStationId, 0, ref stop);
        }

        private static List<PathInformation> Rec(int startStation, int endStation, int busId, ref bool stop)
        {
            if (startStation == endStation)
            {
                stop = true;
                PathInformation inf = new PathInformation(){Bus = BaseConnector.GetBus(busId), 
                    Station = BaseConnector.GetStation(startStation)};
                return new List<PathInformation>() { inf };
            }
            var buses = GetBusIds(startStation);
            foreach (var value in buses)
            {
                if (GetPosition(value, startStation) < paths[value].Count - 1 && !stop)
                {
                    var buff = Rec(paths[value][GetPosition(value, startStation) + 1], endStation, value, ref stop);
                    if (buff!= null)
                    {
                        buff.Add(new PathInformation()
                        {
                            Bus = BaseConnector.GetBus(value),
                            Station = BaseConnector.GetStation(startStation)
                        });
                        return buff;
                    }
                }
            }
            return null;
        }

        private static List<int> GetBusIds(int stationId)
        {
            var list = new List<int>();
                foreach(var bus in paths)
            {
                foreach (var station in bus.Value)
                {
                    if (stationId == station)
                    {
                        list.Add(bus.Key);
                    }
                }
            }
            return list;
        }

        private static int GetPosition(int busId, int stationId)
        {
            return paths[busId].IndexOf(stationId);
        }

    }
}