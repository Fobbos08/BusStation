using Bus.Bussines;
using Bus.Helpers;
using Bus.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus.Controllers
{
    public class PathPageController : Controller
    {
        //
        // GET: /PathPage/

        public ActionResult Index(PathPage currentPage)
        {
            currentPage.StationNames = BaseConnector.GetStations().Select(d => d.Name).OrderBy(d => d).ToList();
            return View(currentPage);
        }

        public ActionResult GetMap(string start, string end)
        {

            return PartialView("~/Views/PathPage/Map.cshtml", PathPageHelper.GetPath(start, end));
        }

    }
}
