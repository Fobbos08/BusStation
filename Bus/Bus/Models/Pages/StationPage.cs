using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus.Models.Pages
{
    public class StationPage
    {
        public string StationName { get; set; }
        public int StationId { get; set; }
        public string StationPosition { get; set; }
        public List<Bus.Bussines.LINQtoSQL.Bus> Buses { get; set; }
    }
}