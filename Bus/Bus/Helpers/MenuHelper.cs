using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus.Helpers
{
    public static class MenuHelper
    {
        public static string DrawMenu()
        {
            //validate on admin
            string result = string.Format("<ul class=\"nav nav-tabs\"><li><a href=\"{0}\">Главная страница</a></li><li><a href=\"{1}\">Маршруты</a></li><li><a href=\"{2}\">Остановки</a></li></ul>", "/StartPage", "/BusListingPage", "/StationListingPage");
            return result;
        }
    }
}