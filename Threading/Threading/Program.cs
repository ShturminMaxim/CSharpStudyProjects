using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    //delegate 
    public delegate void TickEventHadler(object sender, TickArgs args); 

    public class TickArgs:EventArgs {
        public int Tick {get;set;}
        public string Name { get; set; }
    }

    public class Ticker { 
        //create event and its delegate
        int count = 0;
        public int delay { set; get; }
        public string Name { set; get; }
        public event TickEventHadler TickEvent;
        public bool isEnabled { get; set; }
        private int ticks = 0;

        public void RunTicker() {
            Thread.Sleep(this.delay);
            while (isEnabled && TickEvent != null)
            {
                this.ticks++;
                TickEvent(this, new TickArgs() { Tick = this.ticks , Name = this.Name});
                Thread.Sleep(this.delay);
            }
            
        }
    }

    //public class SecondTicker {
    //    Ticker t;

    //    public SecondTicker(Ticker ticker) {
    //        this.t = ticker;
    //        this.t.TickEvent += ticker_TickEvent;
    //    }

    //    void ticker_TickEvent(object sender, TickArgs args)
    //    {
    //        Console.WriteLine("Событие работает в потоке - " + Thread.CurrentThread.Name + ", классе SecontTicker, значение tick - {0}", args.Tick);
    //    }
    //}
    

    class Program
    {
        static void Main(string[] args)
        {
            //Ticker t = new Ticker() { isEnabled = false, delay = 1000, Name = "FirstObject" };
            //Ticker st = new Ticker() { isEnabled = false, delay = 2000, Name = "SecondObject" };

            //t.TickEvent += t_TickEvent;
            //t.isEnabled = true;
            //st.TickEvent += t_TickEvent;
            //st.isEnabled = true;

            //Thread thr1 = new Thread(new ThreadStart(t.RunTicker));
            //thr1.Name = "First Tread";
            //thr1.Start();

            //Thread thr2 = new Thread(new ThreadStart(st.RunTicker));
            //thr2.Name = "     Second Tread";
            //thr2.Start();

            //Thread.Sleep(5000);
            //t.isEnabled = false;
            //st.isEnabled = false;



        }

        static void t_TickEvent(object sender, TickArgs args)
        {
            Console.WriteLine(args.Name + ", Поток - " + Thread.CurrentThread.Name + " , Tick - {0}, Time - {1}", args.Tick, DateTime.Now.TimeOfDay);
        }
    }
}
