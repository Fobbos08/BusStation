using Bus.Bussines;
using Bus.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus.Controllers
{
    public class StationPageController : Controller
    {

        public ActionResult Index(StationPage currentPage)
        {
            var station = BaseConnector.GetStation(currentPage.StationId);
            List<Bus.Bussines.LINQtoSQL.Bus> buses = BaseConnector.GetBuses(currentPage.StationId);
            StationPage sp = new StationPage();
            sp.StationId = station.ID;
            sp.StationName = station.Name;
            sp.StationPosition = station.Position;
            sp.Buses = buses;
            return View(sp);
        }

        public ActionResult GetStationPage(int stationId = -1)
        {
            if (stationId < 0)
            {
                return null;
            }
            var station = BaseConnector.GetStation(stationId);
            StationPage sp = new StationPage();
            sp.StationId = station.ID;
            return RedirectToAction("Index", sp);
        }

    }
}
