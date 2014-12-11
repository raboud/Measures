using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeasuresMVC.Models;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Controllers
{
    public class StoreTypeController : Controller
    {
        private MeasureEntities db = new MeasureEntities();

        // GET: /StoreType/
        public ActionResult Index()
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			return View(db.StoreTypes.ToList());
        }

        // GET: /StoreType/Details/5
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
            StoreType storetype = db.StoreTypes.Find(id);
            if (storetype == null)
            {
                return HttpNotFound();
            }
            return View(storetype);
        }

        // GET: /StoreType/Create
        public ActionResult Create()
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
        }

        // POST: /StoreType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StoreTypeName,ImageName,Logo,QBClass")] StoreType storetype)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (ModelState.IsValid)
            {
                db.StoreTypes.Add(storetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storetype);
        }

        // GET: /StoreType/Edit/5
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
            StoreType storetype = db.StoreTypes.Find(id);
            if (storetype == null)
            {
                return HttpNotFound();
            }
            return View(storetype);
        }

        // POST: /StoreType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StoreTypeName,ImageName,Logo,QBClass")] StoreType storetype)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (ModelState.IsValid)
            {
                db.Entry(storetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storetype);
        }

        // GET: /StoreType/Delete/5
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
            StoreType storetype = db.StoreTypes.Find(id);
            if (storetype == null)
            {
                return HttpNotFound();
            }
            return View(storetype);
        }

        // POST: /StoreType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			StoreType storetype = db.StoreTypes.Find(id);
            db.StoreTypes.Remove(storetype);
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
