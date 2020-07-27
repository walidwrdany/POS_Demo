using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS_Demo.DataModels;

namespace POS_Demo.Controllers
{
    public class SalesController : BaseController
    {
        private POSEntities _db = new POSEntities();

        // GET: Sales
        public ActionResult Index()
        {
            return View(_db.Sales_Person.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Person sales_Person = _db.Sales_Person.Find(id);
            if (sales_Person == null)
            {
                return HttpNotFound();
            }
            return View(sales_Person);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sales_Person sales_Person)
        {
            sales_Person.IsActive = true;
            sales_Person.Created = GetDate;
            sales_Person.CreatedBy = GetUserId;
            sales_Person.LastModified = GetDate;
            sales_Person.LastModifiedBy = GetUserId;

            if (ModelState.IsValid)
            {
                _db.Sales_Person.Add(sales_Person);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sales_Person);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Person sales_Person = _db.Sales_Person.Find(id);
            if (sales_Person == null)
            {
                return HttpNotFound();
            }
            return View(sales_Person);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sales_Person sales_Person)
        {
            sales_Person.IsActive = true;
            sales_Person.LastModified = GetDate;
            sales_Person.LastModifiedBy = GetUserId;

            if (ModelState.IsValid)
            {
                _db.Entry(sales_Person).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sales_Person);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Person sales_Person = _db.Sales_Person.Find(id);
            if (sales_Person == null)
            {
                return HttpNotFound();
            }
            return View(sales_Person);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales_Person sales_Person = _db.Sales_Person.Find(id);
            _db.Sales_Person.Remove(sales_Person);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
