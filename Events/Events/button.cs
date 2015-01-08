using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Button
    {
        public string Name;
        event EventHandler click;

        public Button(string name){
            this.Name = name;

            click += ShowMessage;
        }

        public void ClickEvent() {
            if (click != null)
            {
                click(this, EventArgs.Empty);
            }
        }

        public void ShowMessage(Object btn, EventArgs arr) {
            Button button = (Button)btn;

            Console.WriteLine("This is button "+button.Name);
        }
    } 
}
