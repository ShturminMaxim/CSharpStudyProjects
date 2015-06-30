using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern
{
    static class Facade
    {
        static DataBase db = new DataBase();
        static Website webSite = new Website();

        /// <summary>
        /// Init Database and Website with Name
        /// </summary>
        /// <param name="name"></param>
        public static void initWebsite(string name) {
            db.Create(name);
            db.Start();

            webSite.Init(name);
            webSite.Start();
        }

        /// <summary>
        /// Stop and remove DB , Stop and Remove Website
        /// </summary>
        /// <param name="name"></param>
        public static void removeSite(string name) {
            
            db.Stop(name);
            db.Remove(name);

            webSite.Stop(name);
            webSite.Remove(name);
        }
    }
}
