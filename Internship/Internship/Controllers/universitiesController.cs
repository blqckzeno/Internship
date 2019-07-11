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
    public class universitiesController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: universities
        public ActionResult Index()
        {
            var university = db.university.Include(u => u.users);
            return View(university.ToList());
        }

        // GET: universities/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            university university = db.university.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // GET: universities/Create
        public ActionResult Create()
        {
            ViewBag.representative_id = new SelectList(db.users, "id", "email");
            return View();
        }

        // POST: universities/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,email,address1,address2,city,state,street,zip_code,fax,name,registration_number,tel,web_site,representative_id")] university university)
        {
            if (ModelState.IsValid)
            {
                db.university.Add(university);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.representative_id = new SelectList(db.users, "id", "email", university.representative_id);
            return View(university);
        }

        // GET: universities/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            university university = db.university.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            ViewBag.representative_id = new SelectList(db.users, "id", "email", university.representative_id);
            return View(university);
        }

        // POST: universities/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,email,address1,address2,city,state,street,zip_code,fax,name,registration_number,tel,web_site,representative_id")] university university)
        {
            if (ModelState.IsValid)
            {
                db.Entry(university).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.representative_id = new SelectList(db.users, "id", "email", university.representative_id);
            return View(university);
        }

        // GET: universities/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            university university = db.university.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            university university = db.university.Find(id);
            db.university.Remove(university);
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
