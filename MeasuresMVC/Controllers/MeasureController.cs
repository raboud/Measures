using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MeasuresMVC.Models;
using Microsoft.AspNet.Identity;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Controllers
{

	[Authorize]
	public class MeasureController : Controller
	{
		private MeasureEntities db = new MeasureEntities();
		//[HttpGet]
		//public JsonResult GetOrdersData(string CustomerID)
		//{
		//	var NWE = new NORTHWNDEntities();

		//	var orders = from o in NWE.Orders
		//				 where o.CustomerID == CustomerID
		//				 select o;

		//	JsonResult jr = new JsonResult();
		//	jr.Data = orders.Select(o => new { o.OrderID, o.Freight });
		//	jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

		//	return jr;
		//}

		public ActionResult AddMaterial(int? id)
		{
			AddMaterialModel model = new AddMaterialModel();
			model.MeasureId = id.Value;
			model.MaterialTypeList = db.MaterialTypes.ToList().Select(i => new Lookup(i.Id, i.Description)).ToList();
			model.WidthList = db.Widths.ToList();
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddMaterial(AddMaterialModel model)
		{
			if (ModelState.IsValid)
			{
				Measure m = db.Measures.Find(model.MeasureId);
				if (m != null)
				{
					MeasureMaterial mm = new MeasureMaterial()
					{
						MaterialTypeId = model.Material.MaterialTypeId.Value,
						AltWidthId = model.Material.AltWidthId.Value,
						WidthId = model.Material.WidthId.Value,
						Description = model.Material.Description
					};
					m.Materials.Add(mm);
					int c = db.SaveChanges();
					return RedirectToAction("Details/" + model.MeasureId.ToString());
				}
			}
			return View(model);
		}

		// GET: /Measure/
		public ActionResult Index()
		{
			return View(db.Measures.ToList());
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details(MeasureModel model)
		{
			if (ModelState.IsValid)
			{
				Measure m = (from measure in db.Measures
								 .Include(ma => ma.Materials.Select(r => r.Rooms))
								 .Include(ma => ma.Materials.Select(mt => mt.MaterialType))
							 where measure.Id == model.MeasureId select measure).FirstOrDefault();
				if (m == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				List<Room> Rooms = db.Rooms.ToList();

				foreach (MeasureMaterial mm in m.Materials)
				{
					var rooms = new HashSet<int> (mm.Rooms.Select(c => c.RoomId));
					var newRooms = new HashSet<int>(model.Rooms.Where(z => z.MaterialId == mm.Id).Select(z => z.RoomId));
					foreach (var room in Rooms)
					{
						if (newRooms.Contains(room.Id))
						{
							if (!rooms.Contains(room.Id))
							{
								mm.Rooms.Add(new MeasureRoom() { RoomId = room.Id });
							}
						}
						else
						{
							if (rooms.Contains(room.Id))
							{
								MeasureRoom mr = mm.Rooms.FirstOrDefault(z => z.RoomId == room.Id);
//								mm.Rooms.Remove(mr);
								db.MeasureRooms.Remove(mr);
							}
						}
					}
				}
				int change = db.SaveChanges();
				return RedirectToAction("Details", "Customer", new { id = model.CustomerId });
			}
			model = new MeasureModel();
			model.measure = db.Measures.Find(model.MeasureId);
			model.customer = db.Customers.Find(model.measure.CustomerId);
			model.CustomerId = model.customer.Id;
			model.MeasureId = model.measure.Id;

			ViewBag.MaterialList = InsertEmptyFirst(new SelectList(model.measure.Materials, "Id", "Description", null));
			return View(model);
		}
		// GET: /Measure/Details/5
		public ActionResult Details(int? id, string ReturnUrl)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			MeasureModel model = new MeasureModel();
			model.measure = (from measure in db.Measures
							 .Include(ma => ma.Materials.Select(r => r.Rooms))
							 .Include(ma => ma.Materials.Select(mt => mt.MaterialType))
						 where measure.Id == id.Value
						 select measure).FirstOrDefault();
			if (model.measure == null)
			{
				return HttpNotFound();
			}
			model.customer = db.Customers.Find(model.measure.CustomerId);
			if (model.customer == null)
			{
				return HttpNotFound();
			}
			model.CustomerId = model.customer.Id;
			model.MeasureId = model.measure.Id;

			model.Rooms = new List<RoomModel>();
			foreach (Room r in db.Rooms.OrderBy(r => r.Name))
			{
				RoomModel room = new RoomModel();
				room.RoomId = r.Id;
				room.Name = r.Name;
				foreach (MeasureMaterial mm in model.measure.Materials)
				{
					MeasureRoom mr = mm.Rooms.FirstOrDefault(mr2 => mr2.RoomId == r.Id);
					if (mr != null)
					{
//						room.Name = mr.Name;
						room.MaterialId = mr.MaterialId;
						break;
					}
				}

				model.Rooms.Add(room);
			}
			ViewBag.ReturnUrl = ReturnUrl;

			ViewBag.MaterialList = InsertEmptyFirst(new SelectList(model.measure.Materials, "Id", "Description", null));
			return View(model);
		}

		public IEnumerable<SelectListItem> InsertEmptyFirst(IEnumerable<SelectListItem> list)
		{
			return new[] { new SelectListItem { Text = string.Empty, Value = "-1" } }.Concat(list);
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
		public ActionResult Create([Bind(Include = "Id,Enterred")] Measure measure)
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
		public ActionResult Edit([Bind(Include = "Id,Enterred")] Measure measure)
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
		public ActionResult Delete(int? mid, string ReturnUrl)
		{
			if (mid == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Measure measure = db.Measures.Find(mid);
			if (measure == null)
			{
				return HttpNotFound();
			}
			ViewBag.ReturnUrl = ReturnUrl;
			return View(measure);
		}

		// POST: /Measure/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id, string ReturnUrl)
		{
			Measure measure = db.Measures.Find(id);
			db.Measures.Remove(measure);
			db.SaveChanges();
			return Redirect(ReturnUrl);
		}


		public ActionResult Return()
		{
			return Redirect(Request.UrlReferrer.ToString());
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
