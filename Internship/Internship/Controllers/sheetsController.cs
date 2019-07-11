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
    public class sheetsController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: sheets
        public ActionResult Index()
        {
            return View(db.sheet.ToList());
        }

        // GET: sheets/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sheet sheet = db.sheet.Find(id);
            if (sheet == null)
            {
                return HttpNotFound();
            }
            return View(sheet);
        }

        // GET: sheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sheets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,categorie,created,description,enterprise,problematique,project_title,student_name,updated")] sheet sheet)
        {
            if (ModelState.IsValid)
            {
                db.sheet.Add(sheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sheet);
        }

        // GET: sheets/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sheet sheet = db.sheet.Find(id);
            if (sheet == null)
            {
                return HttpNotFound();
            }
            return View(sheet);
        }

        // POST: sheets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,categorie,created,description,enterprise,problematique,project_title,student_name,updated")] sheet sheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sheet);
        }

        // GET: sheets/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sheet sheet = db.sheet.Find(id);
            if (sheet == null)
            {
                return HttpNotFound();
            }
            return View(sheet);
        }

        // POST: sheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            sheet sheet = db.sheet.Find(id);
            db.sheet.Remove(sheet);
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
