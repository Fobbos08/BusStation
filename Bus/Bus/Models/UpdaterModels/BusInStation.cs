using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus.Models.UpdaterModels
{
    public class BusInStation
    {
        public Dictionary<int, List<int>> TimeWorkDays { get; set; }
        public Dictionary<int, List<int>> TimeFreeDays { get; set; }
        public string StationName { get; set; }
        public int BusNumber { get; set; }
        public string BusName { get; set; }
        public int StationNumber { get; set; }
    }
}