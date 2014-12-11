using Bus.Bussines;
using Bus.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus.Controllers
{
    public class StationListingPageController : Controller
    {
        //
        // GET: /StationListingPage/

        public ActionResult Index(StationListingPage currentPage)
        {
            currentPage.Stations = BaseConnector.GetStations();
            return View(currentPage);
        }

    }
}
