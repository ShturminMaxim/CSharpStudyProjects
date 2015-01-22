using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using town;

namespace Turkey
{
    class Ankara : Town
    {
        public string Name = "Ankara";

        public Ankara(int people = 16542)
        {
            this.People = people;
        }
    }
}
