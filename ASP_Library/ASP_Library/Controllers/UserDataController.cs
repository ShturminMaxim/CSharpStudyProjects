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
            //var userData = db.Books.Where(b => b.Quantity > 0).ToList();
            List<userData> result = new List<userData>();
            try
            {
                //result.LastName = db.Students.Where(s => s.LastName.Contains(data["lastName"])).Select(s => s.LastName).Distinct().ToString();

                //switch (data["who"])
                //{
                //    case "student":
                var student = db.Students.Where(s => s.LastName.Contains(data["lastName"])).Single();
                var scard = db.S_Cards.Where(c => c.Id_Student == student.Id).ToList();

                for (int i = 0; i < scard.Count(); i++)
                {
                    var peopleData = new userData();
                    peopleData.LastName = student.LastName.ToString();
                    peopleData.DateIn = scard[i].DateIn;
                    peopleData.DateOut = scard[i].DateOut;
                    peopleData.Books = db.Books.Where(b => b.Id == scard[i].Id_Book).Single();

                    result.Add(peopleData);
                }

                //result.LastName = student.LastName.ToString();
                //result.DateIn = scard.DateIn;
                //result.DateOut = scard.DateOut;
                //result.Books = db.Books.Where(b => b.Id == scard.Id_Book).Single();

                //        result.S_Card = (ASP_Library.Models.S_Cards)db.S_Cards.Where(b => b.Id_Student == 1).Distinct();
                //        break;
                //    case "teacher":
                //        result.T_Card = (ASP_Library.Models.T_Cards)db.T_Cards.Where(b => b.Id_Teacher == 1).Distinct();
                //        break;
                //}
                return View(result);
            }
            catch
            {
                return View(result);
            }    
            //result.LastName = db.Students.Where(s => s.LastName.Contains(data["lastName"])).Select(s => s.LastName).Distinct().ToString();

            //switch (data["who"])
            //{
            //    case "student":
                    //var student = db.Students.Where(s => s.LastName.Contains(data["lastName"])).Single();
                    //var scard = db.S_Cards.Where(c => c.Id_Student == student.Id).Single();
            
                    //result.LastName = student.LastName.ToString();
                    //result.DateIn = scard.DateIn;
                    //result.DateOut = scard.DateOut;
                    //result.Books = scard.Books;

            //        result.S_Card = (ASP_Library.Models.S_Cards)db.S_Cards.Where(b => b.Id_Student == 1).Distinct();
            //        break;
            //    case "teacher":
            //        result.T_Card = (ASP_Library.Models.T_Cards)db.T_Cards.Where(b => b.Id_Teacher == 1).Distinct();
            //        break;
            //}
            //ASP_Library.Models.userData result = ;
            //ViewBag.Result = JsonConvert.SerializeObject(userData);
            //return View(result);
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
