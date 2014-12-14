using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus.Models
{
    public class PathInformation
    {
        public Bus.Bussines.LINQtoSQL.Bus Bus { get; set; }
        public Bus.Bussines.LINQtoSQL.Station Station { get; set; }
    }
}