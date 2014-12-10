using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bus.Bussines.LINQtoSQL;
namespace Bus.Models.Pages
{
    public class BusListingPage
    {
        public List<Bus.Bussines.LINQtoSQL.Bus> Buses { get; set; }
    }
}