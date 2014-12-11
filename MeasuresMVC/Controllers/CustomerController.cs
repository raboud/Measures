using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infragistics.Web.Mvc;
using MeasuresMVC.Models;
using Microsoft.AspNet.Identity;
using RandREng.MeasureDBEntity;
using RandREng.Types;

namespace MeasuresMVC.Controllers
{
	[Authorize]
	public class CustomerController : Controller
    {
        private MeasureEntities db = new MeasureEntities();
		
		[GridDataSourceAction]
		public ActionResult GetMeasures(int id)
		{
			IQueryable<Measure> list = from c in new MeasureEntities().Measures where c.CustomerId == id orderby c.Id select c;
			return View(list);
		}

		[GridDataSourceAction]
		public ActionResult GetList()
		{
			IQueryable<Customer> list = null;
			try
			{
				if (User.IsInRole("Store"))
				{
					string userId = User.Identity.GetUserId();
					List<int> stores = db.AspNetUsers.Find(userId).Stores.Select(s => s.Id).ToList();
					list = from c in db.Customers
							   .Include(m => m.Measures.Select(me => me.Emails))
							   .Include(m => m.Measures.Select(mm => mm.Materials.Select(mr => mr.Rooms)))
							   .Include(m => m.Measures.Select(s => s.Store))
							   .Where(c => c.Measures.Any(m => stores.Contains(m.StoreId))) orderby c.Id select c;
				}
				else
				{
					list = from c in db.Customers
							   .Include(m => m.Measures.Select(me => me.Emails))
							   .Include(m => m.Measures.Select(mm => mm.Materials.Select(mr => mr.Rooms)))
							   .Include(m => m.Measures.Select(s => s.Store))
						   orderby c.Id
						   select c;
				}
			}
			catch (Exception e)
			{

			}
			return View(list);
		}

        // GET: /Customer/
        public ActionResult Index()
        {
			return View();
        }

        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
			ViewBag.ReturnUrl = Url.Action("Details" + "/" + id.Value, "Customer"); 
			return View(customer);
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,FirstName,LastName,CompanyName,Address,Address2,City,State,ZipCode,Latitude,Longitude,Directions,PhoneNumber1,PhoneNumber2,PhoneNumber3,EmailAddress,LastModifiedBy,LastModifiedDateTime,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if(string.IsNullOrEmpty(customer.PhoneNumber1) && string.IsNullOrEmpty(customer.PhoneNumber2) && string.IsNullOrEmpty(customer.PhoneNumber3))
                {
                    return View(customer);
                }
				customer.PhoneNumber1 = PhoneNumber10Ext.Reformat(customer.PhoneNumber1);
				customer.PhoneNumber2 = PhoneNumber10Ext.Reformat(customer.PhoneNumber2);
				customer.PhoneNumber2 = PhoneNumber10Ext.Reformat(customer.PhoneNumber2);
				customer.LastModifiedById = User.Identity.GetUserId();
				customer.LastModifiedDateTime = DateTime.Now;
				customer.Measures.Add(new Measure()
				{
					EnterredById = User.Identity.GetUserId(),
					Enterred = DateTime.Now,
					StoreId = db.AspNetUsers.Find(User.Identity.GetUserId()).Stores.First().Id
				});
                db.Customers.Add(customer);
                int count = db.SaveChanges();
				return RedirectToAction("Details", "Measure", new { id = customer.Measures.First().Id });
            }

            return View(customer);
        }

		// GET: /Customer/Edit/5
		public ActionResult CreateMeasure(int? id, string returnUrl)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CreateMeasureModel item = new CreateMeasureModel();
			item.customer = db.Customers.Find(id);
			if (item.customer == null)
			{
				return HttpNotFound();
			}
			Measure m = new Measure()
			{
				EnterredById = User.Identity.GetUserId(),
				Enterred = DateTime.Now,
				StoreId = db.AspNetUsers.Find(User.Identity.GetUserId()).Stores.First().Id,
				CustomerId = item.customer.Id
			};
			item.customer.Measures.Add(m);
			int i = db.SaveChanges();
			return RedirectToAction("Details", "Measure", new { id = m.Id });
		}

		// GET: /Customer/Edit/5
		public ActionResult Edit2(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = db.Customers.Find(id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		}

		// POST: /Customer/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit2(Customer customer)
		{
			if (ModelState.IsValid)
			{
				EntityState state = db.Entry(customer).State;
				db.Entry(customer).State = EntityState.Modified;
				try
				{
					customer.LastModifiedById = User.Identity.GetUserId();
					customer.LastModifiedDateTime = DateTime.Now;
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				catch (System.Data.Entity.Validation.DbEntityValidationException e)
				{

				}
			}
			return View(customer);
		}

        // GET: /Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,CompanyName,Address,Address2,City,State,ZipCode,Latitude,Longitude,Directions,PhoneNumber1,PhoneNumber2,PhoneNumber3,EmailAddress,LastModifiedBy,LastModifiedDateTime,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
				try
				{
					customer.PhoneNumber1 = PhoneNumber10Ext.Reformat(customer.PhoneNumber1);
					customer.PhoneNumber2 = PhoneNumber10Ext.Reformat(customer.PhoneNumber2);
					customer.PhoneNumber2 = PhoneNumber10Ext.Reformat(customer.PhoneNumber3);
					customer.LastModifiedById = User.Identity.GetUserId();
					customer.LastModifiedDateTime = DateTime.Now;
					db.Entry(customer).State = EntityState.Modified;
					db.SaveChanges();
				}
				catch (DbEntityValidationException e)
				{

				}
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: /Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


		private void PopulateAssignedCourseData(MeasureMaterial instructor)
		{
			var allRooms = db.Rooms;
			var materialRooms = new HashSet<int>(instructor.Rooms.Select(c => c.RoomId));
			var viewModel = new List<AssignedRoomData>();
			foreach (var room in allRooms)
			{
				viewModel.Add(new AssignedRoomData
				{
					RoomId = room.Id,
					Title = room.Name,
					Assigned = materialRooms.Contains(room.Id)
				});
			}
			ViewBag.Courses = viewModel;
		}

		private void UpdateInstructorCourses(string[] selectedRooms, MeasureMaterial instructorToUpdate)
		{
			if (selectedRooms == null)
			{
				instructorToUpdate.Rooms = new List<MeasureRoom>();
				return;
			}

			var selectedCoursesHS = new HashSet<string>(selectedRooms);
			var instructorCourses = new HashSet<int>
				(instructorToUpdate.Rooms.Select(c => c.RoomId));
			foreach (var room in db.Rooms)
			{
				if (selectedCoursesHS.Contains(room.Name))
				{
					if (!instructorCourses.Contains(room.Id))
					{
						instructorToUpdate.Rooms.Add(new MeasureRoom() { RoomId = room.Id });
					}
				}
				else
				{
					if (instructorCourses.Contains(room.Id))
					{
						instructorToUpdate.Rooms.Remove(instructorToUpdate.Rooms.FirstOrDefault(m => m.RoomId == room.Id));
					}
				}
			}
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
