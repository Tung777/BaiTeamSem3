using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using project_sem_3.Models;

namespace project_sem_3.Controllers
{
    public class ShopController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Product(int? Id, string color)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productSingle = new ProductDetailViewModel();
            Product product = db.Products.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }

            List<ProductDetail> productDetails = db.ProductDetails.Where(pd => pd.ProductId == Id.Value).ToList();
            productSingle.Product = product;
            productSingle.ProductDetails = productDetails;
            ViewBag.totalQuantity = productDetails.Where(m => m.Status == EProductStatus.Active).Sum(m => m.Quantity);

            return View(productSingle);

        }

        public ActionResult Tshirts(int? page)
        {
            var products = from p in db.Products select p;
            products = products.Where(p => p.CategoryId == 1).OrderBy(p => p.CreatedAt);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View("~/Views/Shop/Tshirts.cshtml", products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Shirts(int? page)
        {
            var products = from p in db.Products select p;
            products = products.Where(p => p.CategoryId == 2).OrderBy(p => p.CreatedAt);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View("~/Views/Shop/Shirts.cshtml", products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Shorts(int? page)
        {
            var products = from p in db.Products select p;
            products = products.Where(p => p.CategoryId == 3).OrderBy(p => p.CreatedAt);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View("~/Views/Shop/Shorts.cshtml", products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Jeans(int? page)
        {
            var products = from p in db.Products select p;
            products = products.Where(p => p.CategoryId == 4).OrderBy(p => p.CreatedAt);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View("~/Views/Shop/Jeans.cshtml", products.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
