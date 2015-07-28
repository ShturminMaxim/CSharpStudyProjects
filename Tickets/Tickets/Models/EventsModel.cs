using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tickets.Models
{
    public class EventsModel
    {
            public int EventsModelId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Teaser { get; set; }
            public int? Cost { get; set; }
            public int? Discount { get; set; }

            public int EventsСategoriesModelId { get; set; }
            public virtual EventsСategoriesModel Category { get; set; }

            public int UserId { get; set; }
            public virtual UserProfile User { get; set; }
    }
}