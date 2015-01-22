using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using town;

namespace Iraq
{
    class Bagdad : Town
    {
        public string Name = "Bagdad";

        public Bagdad(int people = 16542)
        {
            this.People = people;
        }
    }
}
