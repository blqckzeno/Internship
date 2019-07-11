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
    public class departmentsController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: departments
        public ActionResult Index()
        {
            var department = db.department.Include(d => d.university).Include(d => d.users);
            return View(department.ToList());
        }

        // GET: departments/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            department department = db.department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: departments/Create
        public ActionResult Create()
        {
            ViewBag.university_id = new SelectList(db.university, "id", "email");
            ViewBag.chief_id = new SelectList(db.users, "id", "email");
            return View();
        }

        // POST: departments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,chief_id,university_id")] department department)
        {
            if (ModelState.IsValid)
            {
                db.department.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.university_id = new SelectList(db.university, "id", "email", department.university_id);
            ViewBag.chief_id = new SelectList(db.users, "id", "email", department.chief_id);
            return View(department);
        }

        // GET: departments/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            department department = db.department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.university_id = new SelectList(db.university, "id", "email", department.university_id);
            ViewBag.chief_id = new SelectList(db.users, "id", "email", department.chief_id);
            return View(department);
        }

        // POST: departments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,chief_id,university_id")] department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.university_id = new SelectList(db.university, "id", "email", department.university_id);
            ViewBag.chief_id = new SelectList(db.users, "id", "email", department.chief_id);
            return View(department);
        }

        // GET: departments/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            department department = db.department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            department department = db.department.Find(id);
            db.department.Remove(department);
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
