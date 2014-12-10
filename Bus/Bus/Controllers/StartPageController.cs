using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Bussines;
using Bus.Models.Pages;
using Bus.Bussines.LINQtoSQL;

namespace Bus.Controllers
{
    public class StartPageController : Controller
    {
        //
        // GET: /StartPage/

        public ActionResult Index(StartPage currentPage)
        {
            //BusBaseDataDataContext _dataContext = new BusBaseDataDataContext();
            //DataUpdateJob j = new DataUpdateJob();
            //j.Update();
             //BusBaseDataDataContext _dataContext = new BusBaseDataDataContext();
             //_dataContext.DeleteDatabase();
             //_dataContext.CreateDatabase();
            return View(currentPage);
        }

    }
}
