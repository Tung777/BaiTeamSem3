using project_sem_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace project_sem_3.Controllers
{
    [RoutePrefix("api/")]
    public class ApiProductController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ApiProduct/GetProcductListModels
        [HttpGet]
        public IEnumerable<Product> GetProcductListModels()
        {
            return db.Products.ToList();
        }

        // GET: api/ApiProduct/GetProductModels/5
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProductModels(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public IEnumerable<Product> GetProductModels1(int quantity)
        {
            return db.Products.OrderBy(m => m.CreatedAt).Take(quantity).ToList();
        }
    }
}
