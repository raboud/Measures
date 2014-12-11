using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeasuresMVC.Models;
using Microsoft.AspNet.Identity;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Controllers
{
    public class MeasureController : Controller
    {
        private MeasureEntities db = new MeasureEntities();

        // GET: /Measure/
        public ActionResult Index()
        {
            return View(db.Measures.ToList());
        }

        // GET: /Measure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }
        public ActionResult Details(Customer customer)
        {
            if (customer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer.Measures.Add(new Measure());
            Measure measure = customer.Measures.First();
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // GET: /Measure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Measure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Enterred")] Measure measure)
        {
            if (ModelState.IsValid)
            {
				measure.EnterredById = User.Identity.GetUserId();
				measure.Enterred = DateTime.Now;
				db.Measures.Add(measure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(measure);
        }

        // GET: /Measure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: /Measure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Enterred")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(measure);
        }

        // GET: /Measure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: /Measure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measure measure = db.Measures.Find(id);
            db.Measures.Remove(measure);
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
