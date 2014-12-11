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
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Controllers
{
	[Authorize(Roles = "Admin")]
	public class MaterialTypeController : Controller
	{
		private MeasureEntities db = new MeasureEntities();

		[GridDataSourceAction]
		public ActionResult GetList()
		{
			IQueryable<MaterialType> list = from c in new MeasureEntities().MaterialTypes orderby c.Id select c;
			return View(list);
		}

        // GET: /MaterialType/
        public ActionResult Index()
        {
            return View(db.MaterialTypes.ToList());
        }

        // GET: /MaterialType/Details/5
        public ActionResult Details(int? id, string ReturnUrl)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialType materialtype = db.MaterialTypes.Find(id);
            if (materialtype == null)
            {
                return HttpNotFound();
            }
            return View(materialtype);
        }

        // GET: /MaterialType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MaterialType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Description")] MaterialType materialtype)
        {
            if (ModelState.IsValid)
            {
                db.MaterialTypes.Add(materialtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialtype);
        }

        // GET: /MaterialType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialType materialtype = db.MaterialTypes.Find(id);
            if (materialtype == null)
            {
                return HttpNotFound();
            }
            return View(materialtype);
        }

        // POST: /MaterialType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Description")] MaterialType materialtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materialtype);
        }

        // GET: /MaterialType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialType materialtype = db.MaterialTypes.Find(id);
            if (materialtype == null)
            {
                return HttpNotFound();
            }
            return View(materialtype);
        }

        // POST: /MaterialType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialType materialtype = db.MaterialTypes.Find(id);
            db.MaterialTypes.Remove(materialtype);
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
