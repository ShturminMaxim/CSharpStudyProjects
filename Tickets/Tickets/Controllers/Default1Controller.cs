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
    public class Default1Controller : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.UserId);
            return View(events.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Event event = db.Events.Find(id);
            if (event == null)
            {
                return HttpNotFound();
            }
            return View(event);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.UserProfiles, "UserId", "UserName", event.AuthorId);
            return View(event);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Event event = db.Events.Find(id);
            if (event == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.UserProfiles, "UserId", "UserName", event.AuthorId);
            return View(event);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.UserProfiles, "UserId", "UserName", event.AuthorId);
            return View(event);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Event event = db.Events.Find(id);
            if (event == null)
            {
                return HttpNotFound();
            }
            return View(event);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event event = db.Events.Find(id);
            db.Events.Remove(event);
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