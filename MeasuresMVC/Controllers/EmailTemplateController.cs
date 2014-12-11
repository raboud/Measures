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
    public class EmailTemplateController : Controller
    {
        private MeasureEntities db = new MeasureEntities();

        // GET: /EmailTemplate/
        public async Task<ActionResult> Index()
        {
            var emailtemplates = db.EmailTemplates.Include(e => e.EmailType);
            return View(await emailtemplates.ToListAsync());
        }

        // GET: /EmailTemplate/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplate emailtemplate = await db.EmailTemplates.FindAsync(id);
            if (emailtemplate == null)
            {
                return HttpNotFound();
            }
            return View(emailtemplate);
        }

        // GET: /EmailTemplate/Create
        public ActionResult Create()
        {
            ViewBag.EmailTypeId = new SelectList(db.EmailTypes, "Id", "Description");
            return View();
        }

        // POST: /EmailTemplate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,EmailTypeId,Name,Content,Active")] EmailTemplate emailtemplate)
        {
            if (ModelState.IsValid)
            {
				emailtemplate.Content = Server.UrlDecode(emailtemplate.Content);
                db.EmailTemplates.Add(emailtemplate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmailTypeId = new SelectList(db.EmailTypes, "Id", "Description", emailtemplate.EmailTypeId);
            return View(emailtemplate);
        }

        // GET: /EmailTemplate/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplate emailtemplate = await db.EmailTemplates.FindAsync(id);
            if (emailtemplate == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmailTypeId = new SelectList(db.EmailTypes, "Id", "Description", emailtemplate.EmailTypeId);
            return View(emailtemplate);
        }

        // POST: /EmailTemplate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,EmailTypeId,Name,Content,Active")] EmailTemplate emailtemplate)
        {
            if (ModelState.IsValid)
            {
				emailtemplate.Content = Server.UrlDecode(emailtemplate.Content);
				db.Entry(emailtemplate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmailTypeId = new SelectList(db.EmailTypes, "Id", "Description", emailtemplate.EmailTypeId);
            return View(emailtemplate);
        }

        // GET: /EmailTemplate/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplate emailtemplate = await db.EmailTemplates.FindAsync(id);
            if (emailtemplate == null)
            {
                return HttpNotFound();
            }
            return View(emailtemplate);
        }

        // POST: /EmailTemplate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmailTemplate emailtemplate = await db.EmailTemplates.FindAsync(id);
            db.EmailTemplates.Remove(emailtemplate);
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
