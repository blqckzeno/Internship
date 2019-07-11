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
    public class documentsController : Controller
    {
        private internshipEntities2 db = new internshipEntities2();

        // GET: documents
        public ActionResult Index()
        {
            var document = db.document.Include(d => d.final_project_assignment);
            return View(document.ToList());
        }

        // GET: documents/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            document document = db.document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: documents/Create
        public ActionResult Create()
        {
            ViewBag.final_project_assignment_id = new SelectList(db.final_project_assignment, "id", "id");
            return View();
        }

        // POST: documents/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date_fichier_alf,fichier_alfresco,format_fichier_alf,id_fichier_alf,nom_fichier_alf,path_fichier_alf,present,size_fichier_alf,final_project_assignment_id")] document document)
        {
            if (ModelState.IsValid)
            {
                db.document.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.final_project_assignment_id = new SelectList(db.final_project_assignment, "id", "id", document.final_project_assignment_id);
            return View(document);
        }

        // GET: documents/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            document document = db.document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.final_project_assignment_id = new SelectList(db.final_project_assignment, "id", "id", document.final_project_assignment_id);
            return View(document);
        }

        // POST: documents/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date_fichier_alf,fichier_alfresco,format_fichier_alf,id_fichier_alf,nom_fichier_alf,path_fichier_alf,present,size_fichier_alf,final_project_assignment_id")] document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.final_project_assignment_id = new SelectList(db.final_project_assignment, "id", "id", document.final_project_assignment_id);
            return View(document);
        }

        // GET: documents/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            document document = db.document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            document document = db.document.Find(id);
            db.document.Remove(document);
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
