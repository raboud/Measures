using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infragistics.Web.Mvc;
using MeasuresMVC.Models;
using Microsoft.AspNet.Identity;
using RandREng.IdentityDBEntity;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Controllers
{
	public class TechController : Controller
	{
		private MeasureEntities db = new MeasureEntities();


		[GridDataSourceAction]
		public ActionResult GetList()
		{
			IQueryable < Tech > list = from c in new MeasureEntities().Teches orderby c.Id select c;

			List<Tech> t = list.ToList();
			return View(list);
		}


		// GET: /Tech/
		public ActionResult Index()
		{
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
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
			MeasuresMVC.Models.TechDetail tech = new Models.TechDetail(db, id.Value);

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
		public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,Address2,City,State,ZipCode,Latitude,Longitude,PhoneNumber1,PhoneNumber2,EmailAddress,LastModifiedBy,LastModifiedDateTime,Name")] Tech model)
		{
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (ModelState.IsValid)
			{
				ApplicationUser user = new ApplicationUser { UserName = model.EmailAddress, Email = model.EmailAddress, FirstName = model.FirstName, LastName = model.LastName, IsConfirmed = true };
				ApplicationDbContext.SCreateUser(user, "cfi12345", "Tech");
				model.UserId = user.Id;

				model.LastModifiedById = User.Identity.GetUserId();
				model.LastModifiedDateTime = DateTime.Now;
				try
				{
					db.Teches.Add(model);
					db.SaveChanges();
				}
				catch (DbEntityValidationException ex)
				{

				}
				return RedirectToAction("Edit2", "Tech", new { id = model.Id });
			}

			return View(model);
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
				return RedirectToAction("Index");
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
		public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,Address2,City,State,ZipCode,Latitude,Longitude,PhoneNumber1,PhoneNumber2,EmailAddress,LastModifiedBy,LastModifiedDateTime,Name")] Tech model)
		{
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (ModelState.IsValid)
			{
				Tech tech2 = db.Teches.Find(model.Id);
				tech2.FirstName = model.FirstName;
				tech2.Address = model.Address;
				tech2.Address2 = model.Address2;
				tech2.City = model.City;
				tech2.PhoneNumber1 = model.PhoneNumber1;
				tech2.LastModifiedById = User.Identity.GetUserId();
				tech2.LastModifiedDateTime = DateTime.Now;
				tech2.LastName = model.LastName;
				tech2.Latitude = model.Latitude;
				tech2.Longitude = model.Longitude;
				tech2.PhoneNumber2 = model.PhoneNumber2;
				tech2.State = model.State;
				tech2.ZipCode = model.ZipCode.Trim();
//				db.Entry(model).State = EntityState.Modified;
				try
				{
					db.SaveChanges();
				}
				catch (DbEntityValidationException e)
				{

				}

				return RedirectToAction("Edit2", "Tech", new { id = model.Id });
			}
			return View(model);
		}

		// GET: /Tech/Edit2/5
		public ActionResult Edit2(int? id)
		{
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (id == null)
			{
				RedirectToAction("Index");
			}
			Tech tech = db.Teches.Find(id);
			if (tech == null)
			{
				return RedirectToAction("Index");
			}
			Edit2ViewModels model = new Edit2ViewModels(tech);
			return View(model);
		}

		// POST: /Tech/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Edit2(Edit2ViewModels model)
		{
			if (!User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home");
			}
			if (ModelState.IsValid)
			{
				Tech tech = db.Teches.Find(model.Id);
				List<TechCapacity> del = new List<TechCapacity>();
				del.AddRange(tech.Capacities);
				foreach (TechCapacity tc in del)
				{
					db.TechCapacities.Remove(tc);
				}
				tech.Capacities.Clear();
				for (byte day = 0; day < 7; day++)
				{
					if (model.Morning[day] > 0)
					{
						tech.Capacities.Add(new TechCapacity() { DayOfWeek = day, Capacity = (byte) model.Morning[day], SlotTypeId = Convert("Morning").Id });
					}
					if (model.Afternoon[day] > 0)
					{
						tech.Capacities.Add(new TechCapacity() { DayOfWeek = day, Capacity = (byte) model.Afternoon[day], SlotTypeId = Convert("Afternoon").Id });
					}
					if (model.Evening[day] > 0)
					{
						tech.Capacities.Add(new TechCapacity() { DayOfWeek = day, Capacity = (byte) model.Evening[day], SlotTypeId = Convert("Evening").Id });
					}
				}
				tech.LastModifiedById = User.Identity.GetUserId();
				tech.LastModifiedDateTime = DateTime.Now;
				try
				{
					//				db.Entry(tech).State = EntityState.Modified;
					db.SaveChanges();
				}
				catch (DbEntityValidationException e)
				{

				}
				catch (DbUpdateException e)
				{

				}
				return RedirectToAction("Index");
			}
			return View(model);
		}

		SlotType Convert(string text)
		{
			return (from st in db.SlotTypes where st.Name == text select st).FirstOrDefault();
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
