using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus.Models.Partials
{
    public class TimeTable
    {
        Dictionary<int, List<int>> timeWorkDays { get; set; }
        Dictionary<int, List<int>> timeFreeDays { get; set; }
    }
}