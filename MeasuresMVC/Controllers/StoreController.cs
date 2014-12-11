using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infragistics.Web.Mvc;
using MeasuresMVC.Models;
using MeasuresMVC.Models.Repositories;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Controllers
{
    public class StoreController : Controller
    {
        private MeasureEntities db = new MeasureEntities();

		[GridDataSourceAction]
		public ActionResult GetList()
		{
			IQueryable<IStoreView> stores = from c in new MeasureEntities().Stores orderby c.Id select c;
			return View(stores);
		}

        // GET: /Store/
        public ActionResult Index()
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
            return View();
        }

        // GET: /Store/Details/5
        public ActionResult Details(int? id)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandREng.MeasureDBEntity.Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: /Store/Create
        public ActionResult Create()
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            ViewBag.TypeID = new SelectList(db.StoreTypes, "Id", "StoreTypeName");
            return View();
        }

        // POST: /Store/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,TypeID,Number,BillingAddress,City,State,ZipCode,StorePhoneNumber,DirectPhoneNumber,Extension,FaxNumber,Notes,BranchId,Active,StoreNickName,Latitude,Longitude,DistrictNumber,IncludeInStatusReportAll")] RandREng.MeasureDBEntity.Store store)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", store.BranchId);
            ViewBag.TypeID = new SelectList(db.StoreTypes, "Id", "StoreTypeName", store.TypeID);
            return View(store);
        }

        // GET: /Store/Edit/5
        public ActionResult Edit(int? id)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandREng.MeasureDBEntity.Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", store.BranchId);
            ViewBag.TypeID = new SelectList(db.StoreTypes, "Id", "StoreTypeName", store.TypeID);
            return View(store);
        }

        // POST: /Store/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,TypeID,Number,BillingAddress,City,State,ZipCode,StorePhoneNumber,DirectPhoneNumber,Extension,FaxNumber,Notes,BranchId,Active,StoreNickName,Latitude,Longitude,DistrictNumber,IncludeInStatusReportAll")] RandREng.MeasureDBEntity.Store store)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", store.BranchId);
            ViewBag.TypeID = new SelectList(db.StoreTypes, "Id", "StoreTypeName", store.TypeID);
            return View(store);
        }

        // GET: /Store/Delete/5
        public ActionResult Delete(int? id)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandREng.MeasureDBEntity.Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: /Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			RandREng.MeasureDBEntity.Store store = db.Stores.Find(id);
			store.Active = false;
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
