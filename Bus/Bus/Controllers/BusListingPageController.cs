using Bus.Bussines;
using Bus.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus.Controllers
{
    public class BusListingPageController : Controller
    {
        public ActionResult Index(BusListingPage currentPage)
        {
            currentPage.Buses = BaseConnector.GetBuses();
            return View(currentPage);
        }
    }
}
