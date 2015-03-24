using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCompact_Entity
{
    class TestContext : DbContext 
    {
        /// <summary>
        /// Inheritance and calling main Entity constructor with connetion to DB named "Test"
        /// </summary>
        public TestContext() : base("Test") { 
            
        }

        /// <summary>
        /// Collection of table rows, Model of our table
        /// </summary>
        public DbSet<People> Peoples { get; set; }
    }

    /// <summary>
    /// Information bout roq insode our table
    /// </summary>
    class People
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
