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
    public class eclassesController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: eclasses
        public ActionResult Index()
        {
            var eclass = db.eclass.Include(e => e.university);
            return View(eclass.ToList());
        }

        // GET: eclasses/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eclass eclass = db.eclass.Find(id);
            if (eclass == null)
            {
                return HttpNotFound();
            }
            return View(eclass);
        }

        // GET: eclasses/Create
        public ActionResult Create()
        {
            ViewBag.university_id = new SelectList(db.university, "id", "email");
            return View();
        }

        // POST: eclasses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,year,university_id")] eclass eclass)
        {
            if (ModelState.IsValid)
            {
                db.eclass.Add(eclass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.university_id = new SelectList(db.university, "id", "email", eclass.university_id);
            return View(eclass);
        }

        // GET: eclasses/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eclass eclass = db.eclass.Find(id);
            if (eclass == null)
            {
                return HttpNotFound();
            }
            ViewBag.university_id = new SelectList(db.university, "id", "email", eclass.university_id);
            return View(eclass);
        }

        // POST: eclasses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,year,university_id")] eclass eclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eclass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.university_id = new SelectList(db.university, "id", "email", eclass.university_id);
            return View(eclass);
        }

        // GET: eclasses/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eclass eclass = db.eclass.Find(id);
            if (eclass == null)
            {
                return HttpNotFound();
            }
            return View(eclass);
        }

        // POST: eclasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            eclass eclass = db.eclass.Find(id);
            db.eclass.Remove(eclass);
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
