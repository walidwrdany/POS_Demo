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
    public class DeveloperController : BaseController
    {
        private POSEntities _db = new POSEntities();

        public ActionResult Index()
        {
            return View(_db.Developers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = _db.Developers.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Developer developer)
        {
            developer.IsActive = true;
            developer.Created = GetDate;
            developer.CreatedBy = GetUserId;
            developer.LastModified = GetDate;
            developer.LastModifiedBy = GetUserId;

            if (ModelState.IsValid)
            {
                _db.Developers.Add(developer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(developer);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = _db.Developers.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Developer developer)
        {
            developer.IsActive = true;
            developer.LastModified = GetDate;
            developer.LastModifiedBy = GetUserId;

            if (ModelState.IsValid)
            {
                _db.Entry(developer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(developer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = _db.Developers.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Developer developer = _db.Developers.Find(id);
            developer.IsActive = false;
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
