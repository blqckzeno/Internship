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
    public class validation_groupController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: validation_group
        public ActionResult Index()
        {
            var validation_group = db.validation_group.Include(v => v.users).Include(v => v.users1).Include(v => v.users2).Include(v => v.users3).Include(v => v.users4);
            return View(validation_group.ToList());
        }

        // GET: validation_group/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            validation_group validation_group = db.validation_group.Find(id);
            if (validation_group == null)
            {
                return HttpNotFound();
            }
            return View(validation_group);
        }

        // GET: validation_group/Create
        public ActionResult Create()
        {
            ViewBag.president_id = new SelectList(db.users, "id", "email");
            ViewBag.reporter_id = new SelectList(db.users, "id", "email");
            ViewBag.internship_director_id = new SelectList(db.users, "id", "email");
            ViewBag.pre_validator_id = new SelectList(db.users, "id", "email");
            ViewBag.supervisor_id = new SelectList(db.users, "id", "email");
            return View();
        }

        // POST: validation_group/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,valid_internship_director,valid_pre_validator,valid_president,valid_reporter,valid_supervisor,internship_director_id,pre_validator_id,president_id,reporter_id,supervisor_id")] validation_group validation_group)
        {
            if (ModelState.IsValid)
            {
                db.validation_group.Add(validation_group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.president_id = new SelectList(db.users, "id", "email", validation_group.president_id);
            ViewBag.reporter_id = new SelectList(db.users, "id", "email", validation_group.reporter_id);
            ViewBag.internship_director_id = new SelectList(db.users, "id", "email", validation_group.internship_director_id);
            ViewBag.pre_validator_id = new SelectList(db.users, "id", "email", validation_group.pre_validator_id);
            ViewBag.supervisor_id = new SelectList(db.users, "id", "email", validation_group.supervisor_id);
            return View(validation_group);
        }

        // GET: validation_group/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            validation_group validation_group = db.validation_group.Find(id);
            if (validation_group == null)
            {
                return HttpNotFound();
            }
            ViewBag.president_id = new SelectList(db.users, "id", "email", validation_group.president_id);
            ViewBag.reporter_id = new SelectList(db.users, "id", "email", validation_group.reporter_id);
            ViewBag.internship_director_id = new SelectList(db.users, "id", "email", validation_group.internship_director_id);
            ViewBag.pre_validator_id = new SelectList(db.users, "id", "email", validation_group.pre_validator_id);
            ViewBag.supervisor_id = new SelectList(db.users, "id", "email", validation_group.supervisor_id);
            return View(validation_group);
        }

        // POST: validation_group/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,valid_internship_director,valid_pre_validator,valid_president,valid_reporter,valid_supervisor,internship_director_id,pre_validator_id,president_id,reporter_id,supervisor_id")] validation_group validation_group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(validation_group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.president_id = new SelectList(db.users, "id", "email", validation_group.president_id);
            ViewBag.reporter_id = new SelectList(db.users, "id", "email", validation_group.reporter_id);
            ViewBag.internship_director_id = new SelectList(db.users, "id", "email", validation_group.internship_director_id);
            ViewBag.pre_validator_id = new SelectList(db.users, "id", "email", validation_group.pre_validator_id);
            ViewBag.supervisor_id = new SelectList(db.users, "id", "email", validation_group.supervisor_id);
            return View(validation_group);
        }

        // GET: validation_group/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            validation_group validation_group = db.validation_group.Find(id);
            if (validation_group == null)
            {
                return HttpNotFound();
            }
            return View(validation_group);
        }

        // POST: validation_group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            validation_group validation_group = db.validation_group.Find(id);
            db.validation_group.Remove(validation_group);
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
