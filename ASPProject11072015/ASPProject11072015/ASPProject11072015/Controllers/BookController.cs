using ASPProject11072015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject11072015.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        LibraryDataContext db = new LibraryDataContext();

        public ActionResult Index()
        {
            var books = db.Books.ToList();
            return View(books);
        }

        public ActionResult AddBook()
        {
            SelectList listPress = new SelectList(db.Press, "Id", "Name");
            SelectList listThemes = new SelectList(db.Themes, "Id", "Name");
            SelectList listAuthor = new SelectList(db.Authors, "Id", "LastName");
            SelectList listCategory = new SelectList(db.Categories, "Id", "Name");
            ViewBag.listPress = listPress;
            ViewBag.listThemes = listThemes;
            ViewBag.listAuthor = listAuthor;
            ViewBag.listCategory = listCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Books book)
        {
            db.Books.InsertOnSubmit(book);
            db.SubmitChanges();            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddItem(FormCollection form)
        {
            var cat = new Categories();
            cat.Name = form["name"];

            db.Categories.InsertOnSubmit(cat);
            db.SubmitChanges();

            return new EmptyResult();
        }

    }
}
