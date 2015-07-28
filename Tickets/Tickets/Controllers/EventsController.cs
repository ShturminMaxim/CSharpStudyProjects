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
    public class EventsController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Events/

        public ActionResult Index()
        {
            var events = db.EventsModel.ToList();
            
            if (events == null)
            {
                return HttpNotFound();
            }

            return View(events);
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int id = 0)
        {
            EventsModel eventsmodel = db.EventsModel.Find(id);
            if (eventsmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventsmodel);
        }

        //
        // GET: /Events/Create

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Events/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventsModel eventsmodel)
        {
            if (ModelState.IsValid)
            {
                db.EventsModel.Add(eventsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.UserProfiles, "UserId", "UserName", eventsmodel.UserId);
            return View(eventsmodel);
        }

        //
        // GET: /Events/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EventsModel eventsmodel = db.EventsModel.Find(id);
            if (eventsmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.UserProfiles, "UserId", "UserName", eventsmodel.UserId);
            return View(eventsmodel);
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventsModel eventsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.UserProfiles, "UserId", "UserName", eventsmodel.UserId);
            return View(eventsmodel);
        }

        //
        // GET: /Events/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EventsModel eventsmodel = db.EventsModel.Find(id);
            if (eventsmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventsmodel);
        }

        //
        // POST: /Events/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsModel eventsmodel = db.EventsModel.Find(id);
            db.EventsModel.Remove(eventsmodel);
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