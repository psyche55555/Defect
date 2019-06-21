using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using project2.Models;

namespace project2.Controllers
{
    public class TestController : ApiController
    {
        defectEntities db = new defectEntities();
        // GET: api/Test
        public List<Test> GetTest()
        {
            var defs = db.Tests;
            return defs.ToList();
        }
        // GET: api//Test
        public Test GetTest(int id)
        {
            var def = db.Tests
                .Where(m => m.testId == id).FirstOrDefault();
            return def;
        }
        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
