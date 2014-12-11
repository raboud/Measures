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

namespace MeasuresMVC.Controllers
{
	[Authorize(Roles = "Admin")]
	public class EmailTypeController : Controller
    {
        private MeasureEntities db = new MeasureEntities();

        // GET: /EmailType/
        public async Task<ActionResult> Index()
        {
            return View(await db.EmailTypes.ToListAsync());
        }

        // GET: /EmailType/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailType emailtype = await db.EmailTypes.FindAsync(id);
            if (emailtype == null)
            {
                return HttpNotFound();
            }
            return View(emailtype);
        }

        // GET: /EmailType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EmailType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Description")] EmailType emailtype)
        {
            if (ModelState.IsValid)
            {
                db.EmailTypes.Add(emailtype);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(emailtype);
        }

        // GET: /EmailType/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailType emailtype = await db.EmailTypes.FindAsync(id);
            if (emailtype == null)
            {
                return HttpNotFound();
            }
            return View(emailtype);
        }

        // POST: /EmailType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Description")] EmailType emailtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailtype).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emailtype);
        }

        // GET: /EmailType/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailType emailtype = await db.EmailTypes.FindAsync(id);
            if (emailtype == null)
            {
                return HttpNotFound();
            }
            return View(emailtype);
        }

        // POST: /EmailType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmailType emailtype = await db.EmailTypes.FindAsync(id);
            db.EmailTypes.Remove(emailtype);
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
