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
    public class StatusController : BaseController
    {
        private POSEntities _db = new POSEntities();

        public ActionResult Index()
        {
            return View(_db.Deal_Status.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal_Status deal_Status = _db.Deal_Status.Find(id);
            if (deal_Status == null)
            {
                return HttpNotFound();
            }
            return View(deal_Status);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Deal_Status deal_Status)
        {
            deal_Status.IsActive = true;
            deal_Status.Created = GetDate;
            deal_Status.CreatedBy = GetUserId;
            deal_Status.LastModified = GetDate;
            deal_Status.LastModifiedBy = GetUserId;

            if (ModelState.IsValid)
            {
                _db.Deal_Status.Add(deal_Status);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deal_Status);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal_Status deal_Status = _db.Deal_Status.Find(id);
            if (deal_Status == null)
            {
                return HttpNotFound();
            }
            return View(deal_Status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Deal_Status deal_Status)
        {
            deal_Status.IsActive = true;
            deal_Status.LastModified = GetDate;
            deal_Status.LastModifiedBy = GetUserId;

            if (ModelState.IsValid)
            {
                _db.Entry(deal_Status).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deal_Status);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal_Status deal_Status = _db.Deal_Status.Find(id);
            if (deal_Status == null)
            {
                return HttpNotFound();
            }
            return View(deal_Status);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deal_Status deal_Status = _db.Deal_Status.Find(id);
            _db.Deal_Status.Remove(deal_Status);
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
