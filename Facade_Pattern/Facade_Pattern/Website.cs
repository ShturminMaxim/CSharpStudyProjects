using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern
{
    class Website
    {
        string siteName = "";

        /// <summary>
        /// Init website
        /// </summary>
        /// <param name="name"></param>
        public void Init(string name)
        {
            if (isValid(name) == true) {
                try
                {
                    siteName = name;

                    this.unpackFiles();
                    this.downloadBaseModules();
                    this.installWebsite();

                    Console.WriteLine("Website " + name + "init.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Validate new Website before creation
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool isValid(string name)
        {
            return true;
        }

        /// <summary>
        /// Install unpacked website files
        /// </summary>
        private void installWebsite() { 
            
        }

        /// <summary>
        /// Start website process
        /// </summary>
        public void Start()
        {
             Console.WriteLine("Website " + siteName + " Start.");
        }

        /// <summary>
        /// Stop website for maintenance
        /// </summary>
        public void Stop(string name)
        {
            Console.WriteLine("Website " + name + " stopped.");
        }

        /// <summary>
        /// Stop website for maintenance
        /// </summary>
        public void Remove(string name)
        {
            Console.WriteLine("Website " + name + " removed.");
        }

        /// <summary>
        /// Unpack website files for initialisation
        /// </summary>
        private void unpackFiles() { 
            
        }
        
        /// <summary>
        /// Download actual website modules for start
        /// </summary>
        private void downloadBaseModules() { 
            
        }
    }
}
