using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeasuresMVC.Models;

namespace MeasuresMVC.Controllers
{
    public class TechController : Controller
    {
        private MeasureEntities db = new MeasureEntities();

        // GET: /Tech/
        public ActionResult Index()
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			return View(db.Teches.ToList());
        }

        // GET: /Tech/Details/5
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
            Tech tech = db.Teches.Find(id);
            if (tech == null)
            {
                return HttpNotFound();
            }
            return View(tech);
        }

        // GET: /Tech/Create
        public ActionResult Create()
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
        }

        // POST: /Tech/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FirstName,LastName,Address,Address2,City,State,ZipCode,Latitude,Longitude,HomeNumber,MobileNumber,EmailAddress,LastModifiedBy,LastModifiedDateTime,Name")] Tech tech)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (ModelState.IsValid)
            {
                db.Teches.Add(tech);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tech);
        }

        // GET: /Tech/Edit/5
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
            Tech tech = db.Teches.Find(id);
            if (tech == null)
            {
                return HttpNotFound();
            }
            return View(tech);
        }

        // POST: /Tech/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FirstName,LastName,Address,Address2,City,State,ZipCode,Latitude,Longitude,HomeNumber,MobileNumber,EmailAddress,LastModifiedBy,LastModifiedDateTime,Name")] Tech tech)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (ModelState.IsValid)
            {
                db.Entry(tech).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tech);
        }

        // GET: /Tech/Delete/5
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
            Tech tech = db.Teches.Find(id);
            if (tech == null)
            {
                return HttpNotFound();
            }
            return View(tech);
        }

        // POST: /Tech/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			Tech tech = db.Teches.Find(id);
            db.Teches.Remove(tech);
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
