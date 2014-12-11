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
	public class StoreController : Controller
	{
		private MeasureEntities db = new MeasureEntities();

		public ActionResult AddTech(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			RandREng.MeasureDBEntity.Store store = db.Stores.Find(id);
			if (store == null)
			{
				return HttpNotFound();
			}
			Models.AddTech item = new Models.AddTech();
			item.Id = id.Value;
			ViewBag.TechId = new SelectList(db.Teches, "Id", "Name", item.TechId);
			return View(item);
		}
		// POST: /Store/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddTech(Models.AddTech item)
		{
			if (ModelState.IsValid)
			{
				RandREng.MeasureDBEntity.Store store = db.Stores.Find(item.Id);
				RandREng.MeasureDBEntity.Tech tech = db.Teches.Find(item.TechId);
				if ((store == null || tech == null ))
				{
					return HttpNotFound();
				}
				if (!store.Techs.Contains(tech))
				{
					store.Techs.Add(tech);
					db.Entry(store).State = EntityState.Modified;
					int c = db.SaveChanges();
				}
				return RedirectToAction("Details", "Store", new { id = item.Id });
			}

			ViewBag.TechId = new SelectList(db.Teches, "Id", "Name", item.TechId);
			return View(item);
		}

		[GridDataSourceAction]
		public ActionResult GetStoreTechs(int id)
		{
			IQueryable<Tech> Techs = (from c in new MeasureEntities().Stores where c.Id == id orderby c.Id select c).SingleOrDefault().Techs.AsQueryable();
			return View(Techs);
		}


		[GridDataSourceAction]
		public ActionResult GetList()
		{
			IQueryable<StoreWithBranch> stores = (IQueryable<StoreWithBranch>) (from c in new MeasureEntities().StoreWithBranches.AsNoTracking() orderby c.Id select c);
			return View(stores);
		}

		// GET: /Store/
		public ActionResult Index()
		{
			ViewBag.Branches = (from c in new MeasureEntities().Branches orderby c.Id select c).ToList();
			return View();
		}

		// GET: /Store/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			RandREng.MeasureDBEntity.Store store = (from c in new MeasureEntities().Stores.Include(c => c.Techs) where c.Id == id.Value select c).FirstOrDefault();
			if (store == null)
			{
				return HttpNotFound();
			}
			return View(store);
		}

		// GET: /Store/Create
		public ActionResult Create()
		{
			ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
			ViewBag.TypeID = new SelectList(db.StoreTypes, "Id", "TypeName");
			return View();
		}

		// POST: /Store/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,TypeID,Number,Address,City,State,ZipCode,StorePhoneNumber,DirectPhoneNumber,FaxNumber,Notes,BranchId,Active,NickName,Latitude,Longitude,DistrictNumber,IncludeInStatusReportAll")] RandREng.MeasureDBEntity.Store store)
		{
			if (ModelState.IsValid)
			{
				db.Stores.Add(store);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", store.BranchId);
			ViewBag.TypeID = new SelectList(db.StoreTypes, "Id", "TypeName", store.TypeID);
			return View(store);
		}

		// GET: /Store/Edit/5
		public ActionResult Edit(int? id)
		{
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
			ViewBag.TypeID = new SelectList(db.StoreTypes, "Id", "TypeName", store.TypeID);
			return View(store);
		}

		// POST: /Store/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,TypeID,Number,Address,City,State,ZipCode,StorePhoneNumber,DirectPhoneNumber,FaxNumber,Notes,BranchId,Active,NickName,Latitude,Longitude,DistrictNumber,IncludeInStatusReportAll")] RandREng.MeasureDBEntity.Store store)
		{
			if (ModelState.IsValid)
			{
				db.Entry(store).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", store.BranchId);
			ViewBag.TypeID = new SelectList(db.StoreTypes, "Id", "TypeName", store.TypeID);
			return View(store);
		}

		// GET: /Store/Delete/5
		public ActionResult Delete(int? id)
		{
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
