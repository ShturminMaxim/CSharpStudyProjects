using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace town
{
    class Town
    {
        public string Name { set; get; }
        public int People { set; get; }

        public static bool operator >(Town obj1, Town obj2)
        {
            return obj1.People > obj2.People;
        }

        public static bool operator <(Town obj1, Town obj2)
        {
            return obj1.People < obj2.People;
        }
    }
}
