using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Library.Models
{
    public class userData
    {
        public string userType { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public Books Books;
        public string LastName { get; set; }
    }
}