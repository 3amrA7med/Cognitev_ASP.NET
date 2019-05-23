using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognitev.Models
{
    public class Campaign
    {
        public string name { get; set; }
        public string country { get; set; }
        public float budget { get; set; }
        public string goal { get; set; }
        public string category { get; set; }

    }
}