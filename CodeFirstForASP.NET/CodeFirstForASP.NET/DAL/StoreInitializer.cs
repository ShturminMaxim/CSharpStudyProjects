using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CodeFirstForASP.NET.Models;

namespace CodeFirstForASP.NET.DAL
{
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var listCategory = new List<Category>{
                new Category{ Name="Овощи"},
                new Category{ Name="Фрукты"},
                new Category{ Name="Выпечка"},
                new Category{ Name="Напитки"}
            };
            listCategory.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();
            var listProduct = new List<Product>{
                new Product{ Name="Рогалик", CategoryId = 3},
                new Product{ Name="Яблоко", CategoryId = 2},
                new Product{ Name="Пиво", CategoryId = 4},
                new Product{ Name="Картошка", CategoryId = 1}
            };
            listProduct.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}