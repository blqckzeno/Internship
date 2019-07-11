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
    public class optionsController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: options
        public ActionResult Index()
        {
            var options = db.options.Include(o => o.department);
            return View(options.ToList());
        }

        // GET: options/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            options options = db.options.Find(id);
            if (options == null)
            {
                return HttpNotFound();
            }
            return View(options);
        }

        // GET: options/Create
        public ActionResult Create()
        {
            ViewBag.department_id = new SelectList(db.department, "id", "name");
            return View();
        }

        // POST: options/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,created,label,updated,department_id")] options options)
        {
            if (ModelState.IsValid)
            {
                db.options.Add(options);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.department_id = new SelectList(db.department, "id", "name", options.department_id);
            return View(options);
        }

        // GET: options/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            options options = db.options.Find(id);
            if (options == null)
            {
                return HttpNotFound();
            }
            ViewBag.department_id = new SelectList(db.department, "id", "name", options.department_id);
            return View(options);
        }

        // POST: options/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,created,label,updated,department_id")] options options)
        {
            if (ModelState.IsValid)
            {
                db.Entry(options).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.department_id = new SelectList(db.department, "id", "name", options.department_id);
            return View(options);
        }

        // GET: options/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            options options = db.options.Find(id);
            if (options == null)
            {
                return HttpNotFound();
            }
            return View(options);
        }

        // POST: options/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            options options = db.options.Find(id);
            db.options.Remove(options);
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
