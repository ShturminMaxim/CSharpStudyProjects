using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceII
{
    interface IEnum
    {
        int Length { get; }
        object Current { get; }
        void Next();
        int Counter { get; }
    }
}
