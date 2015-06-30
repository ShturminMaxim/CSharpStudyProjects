using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern
{
    class DataBase
    {
        string dbName = "";

        /// <summary>
        /// Create new DataBase
        /// </summary>
        /// <param name="name"></param>
        public void Create(string name)
        {
            if (this.isValid(name) == true)
            {
                dbName = name;
                Console.WriteLine("DataBase " + dbName + "inited.");   
            }
        }

        /// <summary>
        /// Remove DB
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            Console.WriteLine("DataBase " + name + " removed.");
        }

        /// <summary>
        /// Validate new Database before creation
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool isValid(string name) {
            return true;
        }

        /// <summary>
        /// Run DataBase process
        /// </summary>
        public void Start()
        {
                Console.WriteLine("DataBase " + dbName + " Started.");
        }

        /// <summary>
        /// Stop DB process
        /// </summary>
        /// <param name="name"></param>
        public void Stop(string name)
        {
            Console.WriteLine("DataBase " + name + " Stopped.");
        }
    }
}
