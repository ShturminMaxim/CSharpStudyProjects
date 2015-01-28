using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    [Serializable]
    class TodoItem
    {
        public string TodoName {set;get;}
        public bool IsDone {set;get;}
        public int Id { set; get; }

        public TodoItem(string text, int id) {
            this.TodoName = text;
            this.IsDone = false;
            this.Id = id;
        }
    }
}
