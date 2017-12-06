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
            return db.Batches.ToList();
        }

        //public List<Student> GetStudntsByBatch(string batch)
        //{
           
        //}
    }
}
