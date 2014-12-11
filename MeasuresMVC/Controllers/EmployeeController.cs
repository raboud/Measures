using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RandREng.MeasureDBEntity;
using RandREng.Types;

namespace MeasuresMVC.Controllers
{
	[Authorize(Roles = "Admin")]
	public class EmployeeController : Controller
    {
        private MeasureEntities db = new MeasureEntities();

        // GET: /Employee/
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.User);
            return View(await employees.ToListAsync());
        }

        // GET: /Employee/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,NickName,Address1,Address2,City,State,Zip,SSN,Email,SMTPEmail,ReceiveCallNotes,UserId,Active,PhoneNumber1,PhoneNumber2")] Employee employee)
        {
            if (ModelState.IsValid)
            {
				employee.PhoneNumber1 = PhoneNumber10.Reformat(employee.PhoneNumber1);
				employee.PhoneNumber2 = PhoneNumber10.Reformat(employee.PhoneNumber2);
				db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", employee.UserId);
            return View(employee);
        }

        // GET: /Employee/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", employee.UserId);
            return View(employee);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="NickName,Address1,Address2,City,State,Zip,SSN,Email,SMTPEmail,ReceiveCallNotes,UserId,Active,PhoneNumber1,PhoneNumber2")] Employee employee)
        {
            if (ModelState.IsValid)
            {
				employee.PhoneNumber1 = PhoneNumber10.Reformat(employee.PhoneNumber1);
				employee.PhoneNumber2 = PhoneNumber10.Reformat(employee.PhoneNumber2);
				db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", employee.UserId);
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
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
