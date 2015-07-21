using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tickets.Models
{
    public class Event
    {
            [Key]
            public int Id { get; set; }
            public int AuthorId { get; set; }
            public int CategoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Teaser { get; set; }
            public int? Cost { get; set; }
            public int? Discount { get; set; }

            [ForeignKey("AuthorId")]
            public virtual UserProfile UserId { get; set; }

            //[ForeignKey("CategoryId")]
            //public virtual EventCategories Id { get; set; }
    }
}