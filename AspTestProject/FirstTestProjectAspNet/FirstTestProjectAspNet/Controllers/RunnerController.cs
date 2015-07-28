using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstTestProjectAspNet.Models;

namespace FirstTestProjectAspNet.Controllers
{
    public class RunnerController : Controller
    {
        //
        // GET: /Runner/
        RunnerContext db = new RunnerContext();

        public ActionResult Index()
        {
           
            return View(db.Runners.ToList());
        }

        //
        // GET: /Runner/Details/5

        public ActionResult Details(int id)
        {
            Runner entry = db.Runners.Find(id);
            return View(entry);
        }

        //
        // GET: /Runner/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Runner/Register

        [HttpPost]
        public ActionResult Register(Runner r)
        {
            try
            {

                db.Runners.Add(r);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Runner/Edit/5

        public ActionResult Edit(int id)
        {
            Runner entry = db.Runners.Find(id);
            return View(entry);
        }

        //
        // POST: /Runner/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Runner r)
        {
            try
            {
                Runner entry = db.Runners.Find(id);
                entry.Age = r.Age;
                entry.LastName = r.LastName;
                entry.FirstName = r.FirstName;
                entry.NameClub = r.NameClub;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Runner/Delete/5

        public ActionResult Delete(int id)
        {
            Runner entry = db.Runners.Find(id);
            return View(entry);
        }

        //
        // POST: /Runner/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                Runner entry = db.Runners.Find(id);
                db.Runners.Remove(entry);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
