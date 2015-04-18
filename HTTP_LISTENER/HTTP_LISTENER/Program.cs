using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_LISTENER
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AttachEventListeners
            //
            // It is important to understand that FiddlerCore calls event handlers on the
            // session-handling thread.  If you need to properly synchronize to the UI-thread
            // (say, because you're adding the sessions to a list view) you must call .Invoke
            // on a delegate on the window handle.
            //

            // Simply echo notifications to the console.  Because Fiddler.CONFIG.QuietMode=true 
            // by default, we must handle notifying the user ourselves.
            Fiddler.FiddlerApplication.OnNotification += delegate(object sender, NotificationEventArgs oNEA) { Console.WriteLine("** NotifyUser: " + oNEA.NotifyString); };
            Fiddler.FiddlerApplication.Log.OnLogString += delegate(object sender, LogEventArgs oLEA) { Console.WriteLine("** LogString: " + oLEA.LogString); };

            Fiddler.FiddlerApplication.BeforeRequest += delegate(Fiddler.Session oS)
            {
                Console.WriteLine("Before request for:\t" + oS.fullUrl);
                // In order to enable response tampering, buffering mode must
                // be enabled; this allows FiddlerCore to permit modification of
                // the response in the BeforeResponse handler rather than streaming
                // the response to the client as the response comes in.
                oS.bBufferResponse = true;
            };

            Fiddler.FiddlerApplication.BeforeResponse += delegate(Fiddler.Session oS)
            {
                Console.WriteLine("{0}:HTTP {1} for {2}", oS.id, oS.responseCode, oS.fullUrl);

                // Uncomment the following two statements to decompress/unchunk the
                // HTTP response and subsequently modify any HTTP responses to replace 
                // instances of the word "Microsoft" with "Bayden"
                //oS.utilDecodeResponse(); oS.utilReplaceInResponse("Microsoft", "Bayden");
            };

            Fiddler.FiddlerApplication.AfterSessionComplete += delegate(Fiddler.Session oS) { Console.WriteLine("Finished session:\t" + oS.fullUrl); };

            // Tell the system console to handle CTRL+C by calling our method that
            // gracefully shuts down the FiddlerCore.
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            #endregion AttachEventListeners

            Console.WriteLine("Starting FiddlerCore...");

            // For the purposes of this demo, we'll forbid connections to HTTPS 
            // sites that use invalid certificates
            Fiddler.CONFIG.IgnoreServerCertErrors = false;

            // Because we've chosen to decrypt HTTPS traffic, makecert.exe must
            // be present in the Application folder.
            Fiddler.FiddlerApplication.Startup(8877, true, true);
            Console.WriteLine("Hit CTRL+C to end session.");

            // Wait Forever for the user to hit CTRL+C.  
            // BUG BUG: Doesn't properly handle shutdown of Windows, etc.
            Object forever = new Object();
            lock (forever)
            {
                System.Threading.Monitor.Wait(forever);
            }
        //    var web = new HttpListener();

        //    web.Prefixes.Add("https://maxymiser.myjetbrains.com:8080/");

        //    Console.WriteLine("Listening..");

        //    web.Start();

        //    Console.WriteLine(web.GetContext());

        //    var context = web.GetContext();

        //    var response = context.Response;

        //    const string responseString = "<html><body>Hello world</body></html>";

        //    var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

        //    response.ContentLength64 = buffer.Length;

        //    var output = response.OutputStream;

        //    output.Write(buffer, 0, buffer.Length);

        //    Console.WriteLine(output);

        //    output.Close();

        //    web.Stop();

        //    Console.ReadKey();
        //}
        //public static void SimpleListenerExample(string[] prefixes)
        //{
        //    if (!HttpListener.IsSupported)
        //    {
        //        Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
        //        return;
        //    }
        //    // URI prefixes are required, 
        //    // for example "http://contoso.com:8080/index/".
        //    if (prefixes == null || prefixes.Length == 0)
        //        throw new ArgumentException("prefixes");

        //    // Create a listener.
        //    HttpListener listener = new HttpListener();
        //    // Add the prefixes. 
        //    foreach (string s in prefixes)
        //    {
        //        listener.Prefixes.Add(s);
        //    }
        //    listener.Start();
        //    Console.WriteLine("Listening...");
        //    // Note: The GetContext method blocks while waiting for a request. 
        //    HttpListenerContext context = listener.GetContext();
        //    HttpListenerRequest request = context.Request;
        //    // Obtain a response object.
        //    HttpListenerResponse response = context.Response;
        //    // Construct a response. 
        //    string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
        //    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        //    // Get a response stream and write the response to it.
        //    response.ContentLength64 = buffer.Length;
        //    System.IO.Stream output = response.OutputStream;
        //    output.Write(buffer, 0, buffer.Length);
        //    // You must close the output stream.
        //    output.Close();
        //    listener.Stop();
        }

        /// <summary>
        /// When the user hits CTRL+C, this event fires.  We use this to shut down and unregister our FiddlerCore.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Shutting down...");
            Fiddler.FiddlerApplication.Shutdown();
            System.Threading.Thread.Sleep(750);
        }
    }
}
