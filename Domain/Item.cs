using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Item
    {
        public int itemId { get; set; }
        public string startDate { get; set;}

        public string endDate { get; set; }

        public string startTime { get; set; }

        public string endTime { get; set; }

        public string description { get; set; }

        public string category { get; set; }

        public string type { get; set; }

        public string house { get; set; }

        public List<MemberCollection> allmembers { get; set; }


        public Item(int id,string startd,string endd,string startt,string endt, string category, string type, string house, string desc,List<MemberCollection>mem)
        {
            this.itemId = id;
            this.startDate = startd;
            this.endDate = endd;
            this.startTime = startt;
            this.endTime = endt;
            this.description = desc;
            this.category = category;
            this.type = type;
            this.house = house;
            this.allmembers = mem;
     
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}]", this.itemId, this.startDate, this.endDate, this.startTime, this.endTime, this.description, this.category, this.type, this.house, this.allmembers.Count);
        }
    }
}
