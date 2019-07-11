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
    public class notificationsController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: notifications
        public ActionResult Index()
        {
            var notification = db.notification.Include(n => n.users);
            return View(notification.ToList());
        }

        // GET: notifications/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notification notification = db.notification.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // GET: notifications/Create
        public ActionResult Create()
        {
            ViewBag.owner_id = new SelectList(db.users, "id", "email");
            return View();
        }

        // POST: notifications/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description,email,message,mobile,name,state,sys_notif_date,owner_id")] notification notification)
        {
            if (ModelState.IsValid)
            {
                db.notification.Add(notification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.owner_id = new SelectList(db.users, "id", "email", notification.owner_id);
            return View(notification);
        }

        // GET: notifications/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notification notification = db.notification.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            ViewBag.owner_id = new SelectList(db.users, "id", "email", notification.owner_id);
            return View(notification);
        }

        // POST: notifications/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,email,message,mobile,name,state,sys_notif_date,owner_id")] notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.owner_id = new SelectList(db.users, "id", "email", notification.owner_id);
            return View(notification);
        }

        // GET: notifications/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notification notification = db.notification.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            notification notification = db.notification.Find(id);
            db.notification.Remove(notification);
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
