using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus.Models.Pages
{
    public class BusPage
    {
        public string BusName { get; set; }
        public int BusId { get; set; }
        public string BusCode { get; set; }
        public List<Bus.Bussines.LINQtoSQL.Station> Stations { get; set; }
    }
}