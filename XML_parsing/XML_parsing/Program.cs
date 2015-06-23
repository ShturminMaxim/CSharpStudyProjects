using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_parsing
{
    class Program
    {
        static void Main(string[] args)
        {

            //XmlTextReader

            //XmlTextReader reader = null;

            //try
            //{
            //    reader = new XmlTextReader("XMLCars.xml");
            //    reader.WhitespaceHandling = WhitespaceHandling.None;

            //    while (reader.Read())
            //    {
                    
            //        //get attributes
            //        if (reader.Name == "car" && reader.GetAttribute("image") != null)
            //        {
            //            Console.WriteLine("Type={0}\t\tName={1}\t\tValue={2}", reader.NodeType, reader.Name, reader.Value);                      
                           
            //            while(reader.MoveToNextAttribute()){
            //                if (reader.NodeType.ToString() == "Attribute" && reader.Name.ToString() == "image")
            //                { 
            //                    Console.WriteLine("Type={0}\t\tName={1}\t\tValue={2}", reader.NodeType, reader.Name, reader.Value);                      
            //                }
                            
            //            }
            //        }
            //    }
            //}
            //finally
            //{
            //    if(reader != null) {
            //        reader.Close();
            //    }
            //}


            XmlTextWriter wr = null;
            try
            {
                wr = new XmlTextWriter("Cars.xml", Encoding.Unicode);
                wr.Formatting = Formatting.Indented; //что бі отступі біли
                wr.WriteStartDocument();
                wr.WriteStartElement("cars");
                wr.WriteStartElement("car");
                wr.WriteAttributeString("image", "image1.jpg");
                wr.WriteElementString("manuactured", "LA Hispano Suiza de Automotives");
                wr.WriteElementString("model", "Alfonso");
                wr.WriteElementString("color", "Black");
                wr.WriteElementString("year", "1912");
                wr.WriteElementString("speed", "200");

                wr.WriteEndElement();
                wr.WriteEndElement();
            }
            finally
            {
               if(wr != null)
                    wr.Close();
            }
        }
    }
}
