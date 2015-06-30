using ASP_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Library.Controllers
{
    public class LibrarianController : Controller
    {
        LibraryDataContext db = new LibraryDataContext();

        //
        // GET: /Librarian/
        public ActionResult GetBook(int id)
        {
            var book = db.Books.Where(b=>b.Id == id).Single();

            ViewBag.Book = book;
            ViewBag.ListStudents = db.Students.ToList();
            S_Cards c = new S_Cards();
            c.Id_Book = id;
            c.DateOut = DateTime.Now;
            c.Id_Lib = 1;

            return View(c);
        }

        [HttpPost]
        public ActionResult GetBook(FormCollection form)
        {
            S_Cards c = new S_Cards();
            c.Id_Book = Convert.ToInt32(form["Id_Book"]);
            c.DateOut = Convert.ToDateTime(form["DateOut"]);
            c.Id_Lib = Convert.ToInt32(form["Id_Lib"]);
            c.Id_Student = Convert.ToInt32(form["student"]);

            db.S_Cards.InsertOnSubmit(c);
            db.SubmitChanges();

            return RedirectToAction("Index","Books");
        }

        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Librarian/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Librarian/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Librarian/Create

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
        // GET: /Librarian/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Librarian/Edit/5

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
        // GET: /Librarian/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Librarian/Delete/5

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
