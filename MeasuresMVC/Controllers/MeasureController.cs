using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Infragistics.Web.Mvc;
using MeasuresMVC.Models;
using Microsoft.AspNet.Identity;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Controllers
{

	[Authorize]
	public class MeasureController : Controller
	{
		private MeasureEntities db = new MeasureEntities();

		public ActionResult AddMaterial(int? id)
		{
			AddMaterialModel model = new AddMaterialModel();
			model.MeasureId = id.Value;
			model.MaterialTypeList = db.MaterialTypes.ToList().Select(i => new Lookup(i.Id, i.Description)).ToList();
			model.WidthList = db.Widths.ToList();
			return View(model);
		}

		[GridDataSourceAction]
		public ActionResult GetList()
		{
			IQueryable<MeasureCustomerStore> list = null;
			try
			{
				if (User.IsInRole("Store"))
				{
					string userId = User.Identity.GetUserId();
					List<int> stores = db.AspNetUsers.Find(userId).Stores.Select(s => s.Id).ToList();
					list = (from m in db.MeasureCustomerStores
							where m.StoreId != null
								&& stores.Contains(m.StoreId.Value)
								&& m.MeasureId != null
								&& ((m.Status.Value & Status.Completed) != Status.Completed || m.Status == null)
							orderby m.Enterred
							select m);
				}
				else
				{
					list = (from m in db.MeasureCustomerStores
							where m.StoreId != null
								&& m.MeasureId != null
								&& ((m.Status.Value & Status.Completed) != Status.Completed || m.Status == null)
							orderby m.Enterred 
							select m);
				}
			}
			catch (Exception e)
			{
				List<MeasureCustomerStore> temp = new List<MeasureCustomerStore>();
				ViewBag.Message = e.Message;
				list = temp.AsQueryable();

			}
			return View(list);
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
						MaterialTypeId = model.MaterialTypeId.Value,
						AltWidthId = model.AltWidthId,
						WidthId = model.WidthId,
						Description = model.Description,
						PatternMatchWidth = model.PatternWidth,
						PatternMatchLength = model.PatternLength
					};
					m.Materials.Add(mm);
					int c = db.SaveChanges();
					return RedirectToAction("Details/" + model.MeasureId.ToString());
				}
			}
			return View(model);
		}
		public ActionResult DeleteMaterial(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			MeasureMaterial mm = db.MeasureMaterials.Find(id);
			if (mm == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			mm.Deleted = true;
			db.SaveChanges();
			return RedirectToAction("Details/" + mm.MeasureId.ToString());
		}

		public ActionResult UndeleteMaterial(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			MeasureMaterial mm = db.MeasureMaterials.Find(id);
			if (mm == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			mm.Deleted = false;
			db.SaveChanges();
			return RedirectToAction("Details/" + mm.MeasureId.ToString());

		}

		public ActionResult EditMaterial(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			EditMaterialModel model = new EditMaterialModel();

			MeasureMaterial mm = db.MeasureMaterials.Find(id);
			model.MeasureMaterialId = id.Value;
			model.AltWidthId = mm.AltWidthId;
			model.Description = mm.Description;
			model.MaterialTypeId = mm.MaterialTypeId;
			model.PatternLength = mm.PatternMatchLength;
			model.PatternWidth = mm.PatternMatchWidth;
			model.WidthId = mm.WidthId;
			model.MaterialTypeList = db.MaterialTypes.ToList().Select(i => new Lookup(i.Id, i.Description)).ToList();
			model.WidthList = db.Widths.ToList();
			model.MeasureId = mm.MeasureId;
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditMaterial(EditMaterialModel model)
		{
			if (ModelState.IsValid)
			{
				MeasureMaterial mm = db.MeasureMaterials.Find(model.MeasureMaterialId);
				if (mm != null)
				{
					mm.MaterialTypeId = model.MaterialTypeId.Value;
					mm.AltWidthId = model.AltWidthId;
					mm.WidthId = model.WidthId;
					mm.Description = model.Description;
					mm.PatternMatchWidth = model.PatternWidth;
					mm.PatternMatchLength = model.PatternLength;
					int c = db.SaveChanges();
					return RedirectToAction("Details/" + mm.MeasureId.ToString());
				}
			}
			model.MaterialTypeList = db.MaterialTypes.ToList().Select(i => new Lookup(i.Id, i.Description)).ToList();
			model.WidthList = db.Widths.ToList();
			return View(model);
		}

		// GET: /Measure/
		public ActionResult Index()
		{
			return View();
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
								 .Include(s => s.Store)
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
							RoomModel rm = model.Rooms.First(r => r.RoomId == room.Id);
							if (!rooms.Contains(room.Id))
							{
								mm.Rooms.Add(new MeasureRoom() { RoomId = room.Id, IncludeCloset = rm.IncludeCloset });
							}
							else
							{
								MeasureRoom mmr = mm.Rooms.First(r => r.RoomId == room.Id);
								mmr.IncludeCloset = rm.IncludeCloset;
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
							 .Include(s => s.Store)
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
				room.ShowCloset = r.ShowCloset;
				foreach (MeasureMaterial mm in model.measure.Materials)
				{
					MeasureRoom mr = mm.Rooms.FirstOrDefault(mr2 => mr2.RoomId == r.Id);
					if (mr != null)
					{
//						room.Name = mr.Name;
						room.MaterialId = mr.MaterialId;
						room.IncludeCloset = mr.IncludeCloset;
						break;
					}
				}

				model.Rooms.Add(room);
			}
			ViewBag.ReturnUrl = ReturnUrl;
			ViewBag.ShowDeleted = true;

			ViewBag.MaterialList = InsertEmptyFirst(new SelectList(model.measure.Materials, "Id", "Description", null));
			return View(model);
		}

		public IEnumerable<SelectListItem> InsertEmptyFirst(IEnumerable<SelectListItem> list)
		{
			return new[] { new SelectListItem { Text = string.Empty, Value = "-1" } }.Concat(list);
		}

		// GET: /Measure/Create
		public ActionResult Create(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Measure model = new Measure();
			model.CustomerId = id.Value;
			List<Lookup> stores;
			if (User.IsInRole("Store"))
			{
				stores = db.AspNetUsers.Find(User.Identity.GetUserId()).Stores.OrderBy(s => s.Number).Where(s => s.Active).Select(i => new Lookup(i.Id, i.Number + " - " + i.NickName)).ToList();
			}
			else
			{
				stores = db.Stores.OrderBy(s => s.Number).Where(s => s.Active).ToList().Select(i => new Lookup(i.Id, i.Number + " - " + i.NickName)).ToList();
			}
			if (stores.Count == 1)
			{
				model.StoreId = stores[0].id;
			}
			ViewBag.StoreList = stores;
			return View(model);
		}

		// POST: /Measure/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Measure measure)
		{
			if (ModelState.IsValid)
			{
				measure.EnterredById = User.Identity.GetUserId();
				measure.Enterred = DateTime.Now;
				db.Measures.Add(measure);
				db.SaveChanges();
				return RedirectToAction("Details/" + measure.Id.ToString());
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
		public ActionResult Edit(MeasureModel model)
		{
			if (ModelState.IsValid)
			{
				db.Entry(model).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Details/" + model.MeasureId.ToString());
			}
			return View(model);
		}

		// GET: /Measure/Delete/5
		public ActionResult Delete(int? id, string ReturnUrl)
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
			ViewBag.ReturnUrl = ReturnUrl;
			return View(measure);
		}

		// POST: /Measure/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id, string ReturnUrl)
		{
			Measure measure = db.Measures.Find(id);
			if (measure == null)
			{
				return HttpNotFound();
			}
			measure.Deleted = true;
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
