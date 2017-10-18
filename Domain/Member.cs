using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Member
    {
      public int memberId { get; set; }

      public string party { get; set; }

      public string memberFrom { get; set; }

      public string fullTitle{ get; set; }


    public Member(int memId,string party,string memFrom,string title)
    {
            this.memberId = memId;
            this.party = party;
            this.memberFrom = memFrom;
            this.fullTitle = title;
    }

     public override string ToString()
     {
       return string.Format("[{0}, {1}, {2}, {3}]", this.memberId, this.party, this.memberFrom, this.fullTitle);
     }

    }
}
