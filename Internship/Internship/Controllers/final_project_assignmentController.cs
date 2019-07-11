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
    public class final_project_assignmentController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: final_project_assignment
        public ActionResult Index()
        {
            var final_project_assignment = db.final_project_assignment.Include(f => f.convention).Include(f => f.validation_group).Include(f => f.users).Include(f => f.sheet);
            return View(final_project_assignment.ToList());
        }

        // GET: final_project_assignment/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            final_project_assignment final_project_assignment = db.final_project_assignment.Find(id);
            if (final_project_assignment == null)
            {
                return HttpNotFound();
            }
            return View(final_project_assignment);
        }

        // GET: final_project_assignment/Create
        public ActionResult Create()
        {
            ViewBag.convention_name = new SelectList(db.convention, "id", "id");
            ViewBag.validation_group_id = new SelectList(db.validation_group, "id", "id");
            ViewBag.student_id = new SelectList(db.users, "id", "email");
            ViewBag.sheet_id = new SelectList(db.sheet, "id", "categorie");
            return View();
        }

        // POST: final_project_assignment/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,convention_name,sheet_id,student_id,validation_group_id")] final_project_assignment final_project_assignment)
        {
            if (ModelState.IsValid)
            {
                db.final_project_assignment.Add(final_project_assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.convention_name = new SelectList(db.convention, "id", "id", final_project_assignment.convention_name);
            ViewBag.validation_group_id = new SelectList(db.validation_group, "id", "id", final_project_assignment.validation_group_id);
            ViewBag.student_id = new SelectList(db.users, "id", "email", final_project_assignment.student_id);
            ViewBag.sheet_id = new SelectList(db.sheet, "id", "categorie", final_project_assignment.sheet_id);
            return View(final_project_assignment);
        }

        // GET: final_project_assignment/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            final_project_assignment final_project_assignment = db.final_project_assignment.Find(id);
            if (final_project_assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.convention_name = new SelectList(db.convention, "id", "id", final_project_assignment.convention_name);
            ViewBag.validation_group_id = new SelectList(db.validation_group, "id", "id", final_project_assignment.validation_group_id);
            ViewBag.student_id = new SelectList(db.users, "id", "email", final_project_assignment.student_id);
            ViewBag.sheet_id = new SelectList(db.sheet, "id", "categorie", final_project_assignment.sheet_id);
            return View(final_project_assignment);
        }

        // POST: final_project_assignment/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,convention_name,sheet_id,student_id,validation_group_id")] final_project_assignment final_project_assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(final_project_assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.convention_name = new SelectList(db.convention, "id", "id", final_project_assignment.convention_name);
            ViewBag.validation_group_id = new SelectList(db.validation_group, "id", "id", final_project_assignment.validation_group_id);
            ViewBag.student_id = new SelectList(db.users, "id", "email", final_project_assignment.student_id);
            ViewBag.sheet_id = new SelectList(db.sheet, "id", "categorie", final_project_assignment.sheet_id);
            return View(final_project_assignment);
        }

        // GET: final_project_assignment/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            final_project_assignment final_project_assignment = db.final_project_assignment.Find(id);
            if (final_project_assignment == null)
            {
                return HttpNotFound();
            }
            return View(final_project_assignment);
        }

        // POST: final_project_assignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            final_project_assignment final_project_assignment = db.final_project_assignment.Find(id);
            db.final_project_assignment.Remove(final_project_assignment);
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
