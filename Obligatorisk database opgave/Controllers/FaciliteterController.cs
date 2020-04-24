using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBContext1;
using ModelKlasser;

namespace Obligatorisk_database_opgave.Controllers
{
    public class FaciliteterController : ApiController
    {
        // GET: api/Facliteter
        public IEnumerable<Faciliteter> Get()
        {
            return new ManageFacliteter().GetAllFacliteter();
        }

        // GET: api/Facliteter/5
        public Faciliteter Get(int id)
        {
            return new ManageFacliteter().GetFacliteterFromId(id);
        }

        // POST: api/Facliteter
        public void Post([FromBody]Faciliteter value)
        {
            new ManageFacliteter().CreateFacilitet(value);
        }

        // PUT: api/Facliteter/5
        public void Put(int id, [FromBody]Faciliteter value)
        {
            new ManageFacliteter().UpdateFacilitet(value, id);
        }

        // DELETE: api/Facliteter/5
        public void Delete(int id)
        {
            new ManageFacliteter().DeleteFacilitet(id);
        }
    }
}
