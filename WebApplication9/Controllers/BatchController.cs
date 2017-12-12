using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiniAttandanceSystem.Controllers
{
    public class BatchController : ApiController
    {
        MiniAttandanceSystemEntities db = new MiniAttandanceSystemEntities();

        [Route("api/GetAllBatches")]
        public List<Batch> GetAllBatches()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Batches.ToList();
        }

        [Route("api/GetStudents/{batch}")]
        public List<Student> GetStudents(string batch)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Students.Where(s => s.Batch.Name == batch).ToList();
        }
    }
}
