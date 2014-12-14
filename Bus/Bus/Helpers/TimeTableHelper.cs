using Bus.Bussines;
using Bus.Models.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus.Helpers
{
    public static class TimeTableHelper
    {
        public static TimeTable GetTimeTable(int busId, int stationId)
        {
            TimeTable table = new TimeTable();
            table.timeFreeDays = BaseConnector.GetFreeTimes(stationId, busId);
            table.timeWorkDays = BaseConnector.GetWorkTimes(stationId, busId);
            table.Saturday = BaseConnector.GetSaturdayTimes(stationId, busId);
            table.Sunday = BaseConnector.GetSundayTimes(stationId, busId);
            return table;
        }
    }
}