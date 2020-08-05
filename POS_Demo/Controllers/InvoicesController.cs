using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS_Demo.DataModels;
using POS_Demo.Helper.Enums;

namespace POS_Demo.Controllers
{
    public class InvoicesController : BaseController
    {
        private POSEntities _db = new POSEntities();

        public ActionResult Index()
        {
            var units_Details = _db.Units_Details.Include(u => u.Developer).Include(u => u.Sales_Person);
            return View(units_Details.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Units_Details units_Details = _db.Units_Details.Find(id);
            if (units_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_DeveloperId = new SelectList(_db.Developers, "Id", "Name", units_Details.FK_DeveloperId);
            ViewBag.FK_Sales_PersonId = new SelectList(_db.Sales_Person, "Id", "Name", units_Details.FK_Sales_PersonId);
            return View(units_Details);
        }

        public ActionResult Create()
        {
            ViewBag.FK_DeveloperId = new SelectList(_db.Developers, "Id", "Name");
            ViewBag.FK_Sales_PersonId = new SelectList(_db.Sales_Person, "Id", "Name");
            return View(new Units_Details()
            {
                SaleDate = this.GetDate
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Units_Details units_Details)
        {
            units_Details.IsActive = true;
            units_Details.Created = GetDate;
            units_Details.CreatedBy = GetUserId;
            units_Details.LastModified = GetDate;
            units_Details.LastModifiedBy = GetUserId;

            if (ModelState.IsValid)
            {
                _db.Units_Details.Add(units_Details);
                _db.SaveChanges();

                var units_Status = new Units_Status()
                {
                    FK_Units_DetailsId = units_Details.Id,
                    FK_Deal_StatusId = (int)Status.Not_Collected,
                    IsActive = true,
                    Created = GetDate,
                    CreatedBy = GetUserId,
                    LastModified = GetDate,
                    LastModifiedBy = GetUserId
                };

                _db.Units_Status.Add(units_Status);
                _db.SaveChanges();

                return RedirectToAction("Details", new { id = units_Details.Id });
            }

            ViewBag.FK_DeveloperId = new SelectList(_db.Developers, "Id", "Name", units_Details.FK_DeveloperId);
            ViewBag.FK_Sales_PersonId = new SelectList(_db.Sales_Person, "Id", "Name", units_Details.FK_Sales_PersonId);
            return View(units_Details);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Units_Details units_Details = _db.Units_Details.Find(id);
            if (units_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_DeveloperId = new SelectList(_db.Developers, "Id", "Name", units_Details.FK_DeveloperId);
            ViewBag.FK_Sales_PersonId = new SelectList(_db.Sales_Person, "Id", "Name", units_Details.FK_Sales_PersonId);
            return View(units_Details);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Units_Details units_Details)
        {
            units_Details.IsActive = true;
            units_Details.LastModified = GetDate;
            units_Details.LastModifiedBy = GetUserId;

            if (ModelState.IsValid)
            {
                _db.Entry(units_Details).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_DeveloperId = new SelectList(_db.Developers, "Id", "Name", units_Details.FK_DeveloperId);
            ViewBag.FK_Sales_PersonId = new SelectList(_db.Sales_Person, "Id", "Name", units_Details.FK_Sales_PersonId);
            return View(units_Details);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Units_Details units_Details = _db.Units_Details.Find(id);
            if (units_Details == null)
            {
                return HttpNotFound();
            }
            return View(units_Details);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Units_Details units_Details = _db.Units_Details.Find(id);
            units_Details.IsActive = false;
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
