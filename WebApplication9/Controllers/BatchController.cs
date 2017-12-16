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

        [HttpGet]
        [Route("api/GetStudntsByBatch/{batch}")]
        public List<Student> GetStudntsByBatch(string batch)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Students.Where(s => s.Batch.BatchCode == batch).ToList();
        }

        [HttpGet]
        [Route("api/MarkAttandance/{sid}")]
        public string MarkAttandance(string sid)
        {
            var students = sid.Split(',').Select(s => Convert.ToInt32(s));

            foreach (var item in students)
            {
                var sa = new StudentAttandance();
                sa.StudentId = item;
                sa.AttandanceDate = DateTime.Now;

                db.StudentAttandances.Add(sa);               
            }

            db.SaveChanges();

            return "done";
        }
    }
}
