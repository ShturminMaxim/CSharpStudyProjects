using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstForASP.NET.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}