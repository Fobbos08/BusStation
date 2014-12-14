using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus.Models.Partials
{
    public class TimeTable
    {
        public Dictionary<int, List<int>> timeWorkDays { get; set; }
        public Dictionary<int, List<int>> timeFreeDays { get; set; }
        public Dictionary<int, List<int>> Sunday { get; set; }
        public Dictionary<int, List<int>> Saturday { get; set; }
    }
}