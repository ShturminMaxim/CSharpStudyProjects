using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    abstract class Figure : IFigure
    {
        public double Height { set; get; }
        public double Width { set; get; }
        public double MainPart { set; get; }
        public int SidesAmount { set; get; }
        public double SidesLenght { set; get; }
        public string Name { get; set; }

        public Figure(string name, int sidesAmount = 0, double sidesLenght = 0)
        {
            this.Name = name;
            this.SidesAmount = sidesAmount;
            this.SidesLenght = sidesLenght;
        }

        public abstract double getArea();
    }
}
