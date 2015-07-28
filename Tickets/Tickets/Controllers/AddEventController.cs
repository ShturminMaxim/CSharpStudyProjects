using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tickets.Models;
using WebMatrix.WebData;

namespace Tickets.Controllers
{
    public class AddEventController : Controller
    {
        //
        // GET: /AddEvent/
        private UsersContext db = new UsersContext();

        public ActionResult Index()
        {
            return PartialView("Index");
        }


        // POST: /AddEvent/Create

        [HttpPost]
        public ActionResult Create(FormCollection data)
        {
            EventsModel newEvent = new EventsModel();
                newEvent.Name = data["Name"];
                newEvent.Description = data["Description"];
                newEvent.Teaser = data["Teaser"];
                newEvent.Cost = Convert.ToInt32(data["Cost"]);
                newEvent.Discount = Convert.ToInt32(data["Discount"]);
                newEvent.UserId = db.UserProfiles.Where(u => u.UserName == User.Identity.Name).Single().UserId;
                newEvent.EventsСategoriesModelId = Convert.ToInt32(data["CategoryId"]);
            
                //This is an emulation of "Entity Link to Category" 
                //newEvent.Category = data["Category.Name"],
                //newEvent.User = c.User["UserName"]

                db.EventsModel.Add(newEvent);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
        }
    }
}
