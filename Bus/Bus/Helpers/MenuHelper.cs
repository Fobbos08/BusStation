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
            string result = string.Format("<ul><li><a href=\"{0}\">StartPage</a></li></ul>", "/StartPage/Index");
            return result;
        }
    }
}