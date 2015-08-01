using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tickets.Filters;
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
        [InitializeSimpleMembership]
        [Authorize(Roles = "Admin")]
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

        [HttpPost]
        [InitializeSimpleMembership]
        [Authorize(Roles = "Admin")]
        public ActionResult UploadFile(HttpPostedFileBase fileData) {
            var result = "";
            var date = new DateTime();
            var seconds = (621355968000000000 - date.ToUniversalTime().Ticks) / 10000000;
            var file = Request.Files[0];

            IEnumerable<string> files;
            if ((file != null) && (file.ContentLength > 0))
            {
                string fileName = file.FileName;
                string saveLocation = @"~/Images";
                string fullFilePath = Path.Combine(Server.MapPath(saveLocation), seconds + "_" + fileName);


                try
                {
                    file.SaveAs(fullFilePath);
                    FileInfo fileInfo = new FileInfo(fullFilePath);
                    file.InputStream.Read(new byte[fileInfo.Length], 0, file.ContentLength);
                    result = seconds + "_" + fileName;
                }
                catch (Exception e)
                {

                    return Json(e.Message);
                }
            }
            else {
                result = "was null";
            }

            return Json(result);
        }
    }
}
