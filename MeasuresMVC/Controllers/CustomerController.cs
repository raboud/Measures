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
using Microsoft.AspNet.Identity;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Controllers
{
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
			IQueryable<Customer> list = from c in new MeasureEntities().Customers.Include(m => m.Measures) orderby c.Id select c;
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
				customer.LastModifiedById = User.Identity.GetUserId();
				customer.LastModifiedDateTime = DateTime.Now;

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Create", "Measure");
            }

            return View(customer);
        }

		// GET: /Customer/Edit/5
		public ActionResult CreateMeasure(int? id)
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
			return View(item);
		}

		// POST: /Customer/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateMeasure(CreateMeasureModel item)
		{
			if (ModelState.IsValid)
			{
			}
			return View(item);
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
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
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
