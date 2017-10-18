using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainChamber.Controllers
{
  
    public class ValuesController : ApiController
    {
        // GET api/values
        static List<Domain.Item> items;
  
        public IEnumerable<Domain.Item> Get()
        {

            Services.CallService servis = new Services.CallService();
            items = servis.initialItems();
        
            return items;
        }


        // GET api/values/5
        public Domain.Item Get(int id)
        {
            Services.CallService servis = new Services.CallService();
            items = servis.initialItems();
            return items.Find(x => x.itemId == id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
