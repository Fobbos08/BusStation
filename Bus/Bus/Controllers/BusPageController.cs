using Bus.Bussines;
using Bus.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus.Controllers
{
    public class BusPageController : Controller
    {
        //
        // GET: /BusPage/

        public ActionResult Index(BusPage currentPage)
        {
            var bus = BaseConnector.GetBus(currentPage.BusId);
            List<Bus.Bussines.LINQtoSQL.Station> stations = BaseConnector.GetStations(currentPage.BusId);
            BusPage bp = new BusPage();
            //if (bus == null) return View("ErrorPage")//!!!!! in current folder
            
                bp.BusCode = bus.Code;
                bp.BusId = bus.ID;
                bp.BusName = bus.Name;
                bp.Stations = new List<Bussines.LINQtoSQL.Station>();
                foreach (var a in stations)
                    bp.Stations.Add(a);
            
            return View(bp);
        }

        public ActionResult GetBusPage(int busId = -1)
        {
            if (busId < 0)
            { 
                return null; 
            }
            var bus = BaseConnector.GetBus(busId);
            BusPage bp = new BusPage();
            bp.BusId = bus.ID;
            return RedirectToAction("Index", bp );
        }

    }
}
