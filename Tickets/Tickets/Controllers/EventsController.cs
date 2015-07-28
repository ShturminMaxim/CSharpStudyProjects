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
            //get all Events from DB
            var events = db.EventsModel.ToList();
            
            //list for JSON parcing
            var list = new List<object>();

            if (events == null)
            {
                return HttpNotFound();
            }

            //for each Event from DB create new object with data needed 
            events.ForEach(c => { var b = new {
                Name=c.Name, 
                Description=c.Description, 
                Teaser=c.Teaser, 
                Cost=c.Cost, 
                Discount=c.Discount,
                //This is an emulation of "Entity Link to Category" 
                Category = c.Category.Name,
                User=c.User.UserName
            }; list.Add(b);
            });

            //return JSON to client
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        // GET: /Events/SearchFor
        
        public ActionResult SearchFor(string categoryName)
        {
            //get all Events from DB
            var events = db.EventsModel.Where(e => e.Category.Name.Contains(categoryName)).Distinct().ToList();

            //list for JSON parcing
            var list = new List<object>();

            if (events == null)
            {
                return HttpNotFound();
            }

            //for each Event from DB create new object with data needed 
            events.ForEach(c =>
            {
                var b = new
                {
                    Name = c.Name,
                    Description = c.Description,
                    Teaser = c.Teaser,
                    Cost = c.Cost,
                    Discount = c.Discount,
                    //This is an emulation of "Entity Link to Category" 
                    Category = c.Category.Name,
                    User = c.User.UserName
                }; list.Add(b);
            });

            //return JSON to client
            return Json(list, JsonRequestBehavior.AllowGet);
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