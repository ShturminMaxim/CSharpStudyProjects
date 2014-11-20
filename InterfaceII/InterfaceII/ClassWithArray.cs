using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceII
{
    class ClassWithArray : IEnum
    {
        string[] randNames = new string[10]{"Cat","Bill","Joe","Van","Den","Val","Elo","Dro","Bron","Eva"};

        public int Counter { get; set; }

        public ClassWithArray(){
            this.Counter = 0;
        }

        public int Length { get {
            return this.randNames.Length;
        }}

        public object Current { get {
            string res = randNames[this.Counter]; 
            if(this.Counter == this.Length) { this.Counter = 0; }
            return res;
        }}

        public void Next() {
            this.Counter += 1;
        }
    }
}
