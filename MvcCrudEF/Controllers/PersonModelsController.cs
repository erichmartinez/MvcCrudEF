using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCrudEF.Models;

namespace MvcCrudEF.Controllers
{
    public class PersonModelsController : Controller
    {
        private PersonModelContext db = new PersonModelContext();

        // GET: PersonModels
        public ActionResult Index()
        {
            return View(db.PersonModelDB.ToList());
        }

        // GET: PersonModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModel personModel = db.PersonModelDB.Find(id);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // GET: PersonModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,Phone,Email")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                db.PersonModelDB.Add(personModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personModel);
        }

        // GET: PersonModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModel personModel = db.PersonModelDB.Find(id);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // POST: PersonModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Phone,Email")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personModel);
        }

        // GET: PersonModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModel personModel = db.PersonModelDB.Find(id);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // POST: PersonModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonModel personModel = db.PersonModelDB.Find(id);
            db.PersonModelDB.Remove(personModel);
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
