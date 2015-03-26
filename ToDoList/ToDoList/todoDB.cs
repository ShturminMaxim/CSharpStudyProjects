using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class todoDB : DbContext 
    {
        /// <summary>
        /// Inheritance and calling main Entity constructor with connetion to DB named "Test"
        /// </summary>
        public todoDB()
            : base("Todo")
        { 
            
        }

        /// <summary>
        /// Collection of table rows, Model of our table
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
