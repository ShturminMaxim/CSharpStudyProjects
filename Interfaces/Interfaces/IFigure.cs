using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IFigure
    {
        string Name { set; get; }
        double Height { set; get; }
        double Width { set; get; }
        double MainPart { set; get; }
        int SidesAmount { set; get; }
        int SidesLenght { set; get; }
    }
}
