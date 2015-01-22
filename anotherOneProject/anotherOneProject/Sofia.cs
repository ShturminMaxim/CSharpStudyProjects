using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using town;

namespace Bulgary
{
    class Sofia : Town
    {
        public string Name = "Sofia";

        public Sofia(int people = 1567)
        {
            this.People = people;
        }
    }
}
