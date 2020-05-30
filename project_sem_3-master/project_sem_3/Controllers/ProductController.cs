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
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly string[] thumbnail;

        // GET: Product
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.CreatedAtSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var product = from p in db.Products select p;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(p => p.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    product = product.OrderByDescending(p => p.Name);
                    break;
                case "Price":
                    product = product.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    product = product.OrderByDescending(p => p.Price);
                    break;
                case "Date":
                    product = product.OrderBy(p => p.CreatedAt);
                    break;
                case "date_desc":
                    product = product.OrderByDescending(p => p.CreatedAt);
                    break;
                default:
                    product = product.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(product.ToPagedList(pageNumber, pageSize));
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,CategoryId,Thumbnails,CreatedAt,UpdatedAt,DeletedAt")] Product products, string[] thumbnails)
        {
            if (ModelState.IsValid)
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    products.Thumbnails = string.Join(",", thumbnails);
                }
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            return View(products);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            return View(products);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,CategoryId,Thumbnails,CreatedAt,UpdatedAt,DeletedAt,CreatedById,UpdatedById,DeletedById")] Product products, string[] thumbnails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            return View(products);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
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
