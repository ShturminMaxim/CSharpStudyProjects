using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using Tickets.Models;
using WebMatrix.WebData;

namespace Tickets.DAL
{
    public class DBInitialiser : DropCreateDatabaseIfModelChanges<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            var newUser = new UserProfile { UserName = "DummyUser", Email = "max@max.com", Phone = "09355522233", UserId = 1 };

            
            //WebSecurity.CreateUserAndAccount(newUser.UserName, "gfhjkmgfhjkm", new { Email = newUser.Email, Phone = newUser.Phone });
            //WebSecurity.Login(newUser.UserName, "gfhjkmgfhjkm");
            
            //listUsers.ForEach(c => context.UserProfiles.Add(c));
            //context.SaveChanges();

            context.UserProfiles.Add(newUser);
            context.SaveChanges();

            //var token = WebSecurity.GeneratePasswordResetToken("Max");
            //var result = WebSecurity.ResetPassword(token, "gfhjkmgfhjkm");

            var listCategory = new List<EventsСategoriesModel>{
                new EventsСategoriesModel{ Name="Night"},
                new EventsСategoriesModel{ Name="Holidays"},
                new EventsСategoriesModel{ Name="Weekend"},
                new EventsСategoriesModel{ Name="Evening"}
            };

            listCategory.ForEach(c => context.EventsСategoriesModel.Add(c));
            context.SaveChanges();

            var listEvents = new List<EventsModel>{
                new EventsModel{ 
                    Name="Auto Party", 
                    Description="autopaty event descr", 
                    Teaser="teaser image", 
                    Cost=19, 
                    Discount=10, 
                    EventsСategoriesModelId = 1, 
                    UserId=1
                },
                new EventsModel{ 
                    Name="Picnic", 
                    Description="Picnic event descr", 
                    Teaser="picnic teaser image", 
                    Cost=19, 
                    Discount=10, 
                    EventsСategoriesModelId = 3,
                    UserId=1
                },
            };
            listEvents.ForEach(p => context.EventsModel.Add(p));
            context.SaveChanges();

            //Roles.AddUserToRole(newUser.UserName, "Admin");
        }
    }
}