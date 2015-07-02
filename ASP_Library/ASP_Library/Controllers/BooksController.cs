using ASP_Library.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Library.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/
        LibraryDataContext db = new LibraryDataContext();

        public ActionResult Index()
        {
            var listBooks = db.Books.Where(b=>b.Quantity > 0);

            ViewBag.ListBooks = listBooks.ToList();
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var textSearch = form["textSearch"];
            //var type = form["searchType"];
            //var listBooks = db.Books.Where(b => b.Quantity > 0).Distinct();
            var listBooks = db.Books.Where(b => b.Quantity > 0).Distinct();
            var checkboxes = form["searchType"].Split(',');
            var changed = false;
            //ViewBag.Checkboxes = checkboxes;

            //listBooks.ToList().Concat(db.Books.Where(b => b.Authors.FirstName.Contains(textSearch)).ToList());

            for (int i = 0; i < checkboxes.Count(); i++)
            {
                var item = checkboxes[i];
                switch (item)
                {
                    case "author":
                        if (changed == false) {
                            listBooks = db.Books.Where(b => b.Authors.FirstName.Contains(textSearch));
                        } else {
                            changed = true;
                            listBooks.Union(db.Books.Where(b => b.Authors.FirstName.Contains(textSearch)));
                        }
                        break;
                    case "category":
                        if (changed == false)
                        {
                            listBooks = db.Books.Where(b => b.Authors.FirstName.Contains(textSearch));
                        }
                        else
                        {
                            changed = true;
                            listBooks.Union(db.Books.Where(b => b.Categories.Name.Contains(textSearch)));
                        }
                        
                        break;
                    case "theme":
                        if (changed == false)
                        {
                            listBooks = db.Books.Where(b => b.Authors.FirstName.Contains(textSearch));
                        }
                        else
                        {
                            changed = true;
                            listBooks.Union(db.Books.Where(b => b.Themes.Name.Contains(textSearch)));
                        }
                       
                        break;
                    case "press":
                        if (changed == false)
                        {
                            listBooks = db.Books.Where(b => b.Authors.FirstName.Contains(textSearch));
                        }
                        else
                        {
                            changed = true;
                            listBooks.Union(db.Books.Where(b => b.Press.Name.Contains(textSearch)));
                        }
                        
                        break;
                    case "name":
                        if (changed == false)
                        {
                            listBooks = db.Books.Where(b => b.Authors.FirstName.Contains(textSearch));
                        }
                        else
                        {
                            changed = true;
                            listBooks.Union(db.Books.Where(b => b.Name.Contains(textSearch)));
                        }
                        
                        break;
                }
            }
            
            //switch (type)
            //{
            //    case "author":
            //        listBooks = db.Books.Where(b => b.Authors.FirstName.Contains(textSearch));
            //        break;
            //    case "category":
            //        listBooks = db.Books.Where(b => b.Categories.Name.Contains(textSearch));
            //        break;
            //    case "theme":
            //        listBooks = db.Books.Where(b => b.Themes.Name.Contains(textSearch));
            //        break;
            //    case "press":
            //        listBooks = db.Books.Where(b => b.Press.Name.Contains(textSearch));
            //        break;
            //    case "name":
            //        listBooks = db.Books.Where(b => b.Name.Contains(textSearch));
            //        break;
            //}
   
            ViewBag.ListBooks = listBooks.ToList(); 

            return View();
        }

        //[HttpGet]
        //public ActionResult Index(string bookName)
        //{
        //    var listBooks = db.Books.Where(b => b.Name.Contains(bookName));
        //    ViewBag.ListBooks = listBooks.ToList();

        //    return View();
        //}

        //
        // GET: /Books/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Books/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Books/Create

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
        // GET: /Books/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Books/Edit/5

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
        // GET: /Books/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Books/Delete/5

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
