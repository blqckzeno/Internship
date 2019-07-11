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
    public class gradesController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: grades
        public ActionResult Index()
        {
            var grade = db.grade.Include(g => g.users).Include(g => g.sheet);
            return View(grade.ToList());
        }

        // GET: grades/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grade grade = db.grade.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // GET: grades/Create
        public ActionResult Create()
        {
            ViewBag.maker_id = new SelectList(db.users, "id", "email");
            ViewBag.sheet_id = new SelectList(db.sheet, "id", "categorie");
            return View();
        }

        // POST: grades/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,level,note,number,maker_id,sheet_id")] grade grade)
        {
            if (ModelState.IsValid)
            {
                db.grade.Add(grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maker_id = new SelectList(db.users, "id", "email", grade.maker_id);
            ViewBag.sheet_id = new SelectList(db.sheet, "id", "categorie", grade.sheet_id);
            return View(grade);
        }

        // GET: grades/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grade grade = db.grade.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            ViewBag.maker_id = new SelectList(db.users, "id", "email", grade.maker_id);
            ViewBag.sheet_id = new SelectList(db.sheet, "id", "categorie", grade.sheet_id);
            return View(grade);
        }

        // POST: grades/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,level,note,number,maker_id,sheet_id")] grade grade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maker_id = new SelectList(db.users, "id", "email", grade.maker_id);
            ViewBag.sheet_id = new SelectList(db.sheet, "id", "categorie", grade.sheet_id);
            return View(grade);
        }

        // GET: grades/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grade grade = db.grade.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // POST: grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            grade grade = db.grade.Find(id);
            db.grade.Remove(grade);
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
