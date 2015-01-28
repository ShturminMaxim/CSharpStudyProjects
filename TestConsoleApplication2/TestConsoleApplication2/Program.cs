using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string formUrl = ""; // NOTE: This is the URL the form POSTs to, not the URL of the form (you can find this in the "action" attribute of the HTML's form tag
            string formParams = string.Format("Login={0}&Password={1}", "", "");
            string cookieHeader;
            WebRequest req = WebRequest.Create(formUrl);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(formParams);
            req.ContentLength = bytes.Length;
            using (Stream os = req.GetRequestStream())
            {
                os.Write(bytes, 0, bytes.Length);
            }
            WebResponse resp = req.GetResponse();
            cookieHeader = resp.Headers["Set-cookie"];

            Console.WriteLine(cookieHeader);

            //

            string pageSource;
            string getUrl = "";
            WebRequest getRequest = WebRequest.Create(getUrl);
            getRequest.Headers.Add("Cookie", cookieHeader);
            WebResponse getResponse = getRequest.GetResponse();
            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                pageSource = sr.ReadToEnd();
            }

            Console.WriteLine(pageSource);
        }
    }
}
