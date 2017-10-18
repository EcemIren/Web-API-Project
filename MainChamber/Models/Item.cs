using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainChamber.Models
{
    public class Item
    {
        public int itemId { get; set; }
        public string startDate { get; set; }

        public string endDate { get; set; }

        public string startTime { get; set; }

        public string endTime { get; set; }

        public string description { get; set; }

        public string category { get; set; }

        public string type { get; set; }

        public string house { get; set; }
    }
}