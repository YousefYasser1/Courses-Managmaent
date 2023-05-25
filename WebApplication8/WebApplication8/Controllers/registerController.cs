using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class registerController : Controller
    {
        private Model1 db = new Model1();

        // GET: register
        public async Task<ActionResult> Index()
        {
            var registations = db.registations.Include(r => r.batch).Include(r => r.course);
            return View(await registations.ToListAsync());
        }

        // GET: register/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = await db.registations.FindAsync(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            return View(registation);
        }

        // GET: register/Create
        public ActionResult Create()
        {
            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1");
            ViewBag.course_id = new SelectList(db.courses, "id", "course1");
            return View();
        }

        // POST: register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] registation registation)
        {
            if (ModelState.IsValid)
            {
                db.registations.Add(registation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1", registation.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "id", "course1", registation.course_id);
            return View(registation);
        }

        // GET: register/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = await db.registations.FindAsync(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1", registation.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "id", "course1", registation.course_id);
            return View(registation);
        }

        // POST: register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] registation registation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1", registation.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "id", "course1", registation.course_id);
            return View(registation);
        }

        // GET: register/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = await db.registations.FindAsync(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            return View(registation);
        }

        // POST: register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            registation registation = await db.registations.FindAsync(id);
            db.registations.Remove(registation);
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
