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
    public class enterprisesController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: enterprises
        public ActionResult Index()
        {
            var enterprise = db.enterprise.Include(e => e.users);
            return View(enterprise.ToList());
        }

        // GET: enterprises/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enterprise enterprise = db.enterprise.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            return View(enterprise);
        }

        // GET: enterprises/Create
        public ActionResult Create()
        {
            ViewBag.representative_id = new SelectList(db.users, "id", "email");
            return View();
        }

        // POST: enterprises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,address1,address2,city,state,street,zip_code,domain,email,email_supervisor,name,web_site,representative_id")] enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                db.enterprise.Add(enterprise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.representative_id = new SelectList(db.users, "id", "email", enterprise.representative_id);
            return View(enterprise);
        }

        // GET: enterprises/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enterprise enterprise = db.enterprise.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            ViewBag.representative_id = new SelectList(db.users, "id", "email", enterprise.representative_id);
            return View(enterprise);
        }

        // POST: enterprises/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,address1,address2,city,state,street,zip_code,domain,email,email_supervisor,name,web_site,representative_id")] enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enterprise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.representative_id = new SelectList(db.users, "id", "email", enterprise.representative_id);
            return View(enterprise);
        }

        // GET: enterprises/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enterprise enterprise = db.enterprise.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            return View(enterprise);
        }

        // POST: enterprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            enterprise enterprise = db.enterprise.Find(id);
            db.enterprise.Remove(enterprise);
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
