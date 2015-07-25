using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tickets.Models;

namespace Tickets.Controllers
{
    public class EventCategoriesController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /EventCategories/

        public ActionResult Index()
        {
            return View(db.EventsСategoriesModel.ToList());
        }

        //
        // GET: /EventCategories/Details/5

        public ActionResult Details(int id = 0)
        {
            EventsСategoriesModel eventsсategoriesmodel = db.EventsСategoriesModel.Find(id);
            if (eventsсategoriesmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventsсategoriesmodel);
        }

        //
        // GET: /EventCategories/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EventCategories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventsСategoriesModel eventsсategoriesmodel)
        {
            if (ModelState.IsValid)
            {
                db.EventsСategoriesModel.Add(eventsсategoriesmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventsсategoriesmodel);
        }

        //
        // GET: /EventCategories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EventsСategoriesModel eventsсategoriesmodel = db.EventsСategoriesModel.Find(id);
            if (eventsсategoriesmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventsсategoriesmodel);
        }

        //
        // POST: /EventCategories/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventsСategoriesModel eventsсategoriesmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventsсategoriesmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventsсategoriesmodel);
        }

        //
        // GET: /EventCategories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EventsСategoriesModel eventsсategoriesmodel = db.EventsСategoriesModel.Find(id);
            if (eventsсategoriesmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventsсategoriesmodel);
        }

        //
        // POST: /EventCategories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsСategoriesModel eventsсategoriesmodel = db.EventsСategoriesModel.Find(id);
            db.EventsСategoriesModel.Remove(eventsсategoriesmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}