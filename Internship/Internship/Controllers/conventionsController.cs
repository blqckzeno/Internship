using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Internship.Models;

namespace Internship.Controllers
{
    public class conventionsController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: conventions
        public ActionResult Index()
        {
            var convention = db.convention.Include(c => c.university);
            return View(convention.ToList());
        }

        // GET: conventions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            convention convention = db.convention.Find(id);
            if (convention == null)
            {
                return HttpNotFound();
            }
            return View(convention);
        }

        // GET: conventions/Create
        public ActionResult Create()
        {
            ViewBag.university_id = new SelectList(db.university, "id", "email");
            return View();
        }

        // POST: conventions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,created,end_date,start_date,updated,valid,university_id")] convention convention)
        {
            if (ModelState.IsValid)
            {
                db.convention.Add(convention);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.university_id = new SelectList(db.university, "id", "email", convention.university_id);
            return View(convention);
        }

        // GET: conventions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            convention convention = db.convention.Find(id);
            if (convention == null)
            {
                return HttpNotFound();
            }
            ViewBag.university_id = new SelectList(db.university, "id", "email", convention.university_id);
            return View(convention);
        }

        // POST: conventions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,created,end_date,start_date,updated,valid,university_id")] convention convention)
        {
            if (ModelState.IsValid)
            {
                db.Entry(convention).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.university_id = new SelectList(db.university, "id", "email", convention.university_id);
            return View(convention);
        }

        // GET: conventions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            convention convention = db.convention.Find(id);
            if (convention == null)
            {
                return HttpNotFound();
            }
            return View(convention);
        }

        // POST: conventions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            convention convention = db.convention.Find(id);
            db.convention.Remove(convention);
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
