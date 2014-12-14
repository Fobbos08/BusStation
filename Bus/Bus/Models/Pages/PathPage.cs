using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus.Models.Pages
{
    public class PathPage
    {
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public List<string> StationNames { get; set; }
    }
}