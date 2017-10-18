using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainChamber.Controllers
{
    public class MembersController : ApiController
    {
        // GET: api/Members
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Members/5
        public Domain.Member Get(int id)
        {
            Services.CallService servis = new Services.CallService();
            Domain.Member member = servis.loadMemberDetails(id);
            return member;
        }

        // POST: api/Members
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Members/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Members/5
        public void Delete(int id)
        {
        }
    }
}
