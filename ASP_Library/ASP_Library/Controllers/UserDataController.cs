using ASP_Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Library.Controllers
{
    public class UserDataController : Controller
    {
        LibraryDataContext db = new LibraryDataContext();

        //
        // GET: /UserData/

        public ActionResult Index()
        {
            List<userData> result = new List<userData>();
            return View(result);
        }

        // POST: /UserData
        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            List<userData> result = new List<userData>();
            string userType = data["who"];

           // dynamic user = null;
            dynamic card = null;

            try
            {
                switch (userType)
                {
                    case "student":
                        Students user = db.Students.Where(s => s.LastName.Contains(data["lastName"])).Single();
                        card = db.S_Cards.Where(c => c.Id_Student == user.Id).ToList();
                        break;
                    case "teacher":
                        Teachers user = db.Teachers.Where(s => s.LastName.Contains(data["lastName"])).Single();
                        card = db.T_Cards.Where(c => c.Id_Teacher == user.Id).ToList();
                        break;
                }


                for (int i = 0; i < card.Count(); i++)
                {
                    var peopleData = new userData();
                    peopleData.LastName = user.LastName.ToString();
                    peopleData.DateIn = card[i].DateIn;
                    peopleData.DateOut = card[i].DateOut;
                    peopleData.Books = db.Books.Where(b => b.Id == card[i].Id_Book).Single();
                    peopleData.userType = userType;

                    result.Add(peopleData);
                }

                return View(result);
            }
            catch
            {
                return View(result);
            }    
        }

        static List<userData> getList(dynamic user)
        {
            return 
        }

        //
        // GET: /UserData/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /UserData/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserData/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserData/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UserData/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserData/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UserData/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
