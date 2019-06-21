using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using project2.Models;

namespace project2.Controllers
{
    public class DefectController : ApiController
    {
        defectEntities db = new defectEntities();
        // GET: api/Defect/train
        public List<train> Get()
        {
            var defs = db.trains;
            return defs.ToList();
        }
        public train Get(int id)
        {
            var def = db.trains
                .Where(m => m.trainId == id).FirstOrDefault();
            return def;
        }

        // POST: api/Defect
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Defect/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Defect/5
        public void Delete(int id)
        {
        }
    }
}
