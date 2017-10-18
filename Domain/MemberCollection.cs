using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MemberCollection
    {
        public int memberId { get; set; }

        public string name { get; set; }
    

    public MemberCollection(int id, string name)
    {
        this.memberId = id;
        this.name = name;
    }
}
}