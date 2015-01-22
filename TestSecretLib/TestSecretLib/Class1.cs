using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSecretLib
{
    public class SecretChest
    {
        public bool isOpened { set; get; }

        public SecretChest() {
            this.isOpened = false; 
        }
        public void OpenSecret() {
            if (this.isOpened == false)
            {
                Console.WriteLine("You Open secret Chest, you got 1000gold");
                this.isOpened = true;
            }
            else {
                Console.WriteLine("Nothing here... go away man.");
            }
        }
    }
}
