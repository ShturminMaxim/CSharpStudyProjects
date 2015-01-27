using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class TodoItem
    {
        public string TodoName {set;get;}
        public bool IsDone {set;get;}

        public TodoItem(string text) {
            this.TodoName = text;
            this.IsDone = false;
        }
    }
}
