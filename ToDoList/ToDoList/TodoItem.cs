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
        public DateTime CreationDate { set; get; }

        public TodoItem(string text, int id, DateTime date) {
            this.TodoName = text;
            this.IsDone = false;
            this.Id = id;
            this.CreationDate = date;
        }
    }
}
