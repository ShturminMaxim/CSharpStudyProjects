using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tickets.Models
{
    public class EventsСategoriesModel
    {
        public int EventsСategoriesModelId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EventsModel> EventsData { get; set; }
    }
}