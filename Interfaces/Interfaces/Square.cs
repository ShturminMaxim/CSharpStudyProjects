using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Square: Figure
    {
        public Square(string name, int sidesAmount, double sidesLenght)
            : base(name, sidesAmount, sidesLenght)
        { 

        }
        
        public override double getArea()
        {
            return this.SidesLenght * this.SidesLenght;
        }

        public override string ToString()
        {
            return base.ToString() + ", Sides amount-" + this.SidesAmount + ".Sides length-" + this.SidesLenght;
        }
    }
}
