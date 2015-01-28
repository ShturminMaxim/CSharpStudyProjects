using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class DBController
    {
        private string FileName {set;get;}
        private List<Client> Clients {set;get;}

        public DBController()
        {
            Clients = new List<Client>();
            GetdataFromFile();

        }

        public List<Client> GetDb(){
            return Clients;
        }

        public bool AddItem(Client client){
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                Clients.Add(client);

                bf.Serialize(fs, Clients);
                fs.Close();

                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        private void GetdataFromFile() {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Clients = (List<Client>)bf.Deserialize(fs);
        }
    }
}
