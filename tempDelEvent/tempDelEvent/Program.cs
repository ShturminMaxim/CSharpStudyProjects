using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace tempDelEvent
{
    enum LightsColor
    { 
        Red,
        Yellow,
        Green
    }

    public delegate void AEventColorRed (object sender,EventArgs e);
    public delegate void AEventColorGreen (object sender,EventArgs e);

    class TrafficLigtsPublishert
    {


        public void Run()
        {
            
            for (;;)
            {
                _currentColor = LightsColor.Green;
                if (_eventGreenHandler != null)
                {
                    _eventGreenHandler(this, new EventArgs());
                    Console.WriteLine("Горит Green");
                }
                System.Thread.Sleep();
                    // ....
             //   System.Thread.Sleep();
                // Sleep (4)
                _currentColor = LightsColor.Red;
                if (_eventGreenHandler != null)
                {
                    _eventGreenHandler(this, new EventArgs());
                    Console.WriteLine("Горит RED");
                }
              }
        }
        public event AEventColorGreen AevenGreen
        {
            add
            {
                _eventGreenHandler += value;
            }
            remove
            {
                _eventGreenHandler -= value;
            }
        }
        public event AEventColorRed AevenrRed
        {
            add
            {
                _eventRedHandler += value;
            }
            remove
            {
                _eventRedHandler -= value;
            }
        }

        LightsColor _currentColor;

        private AEventColorGreen  _eventGreenHandler;
        private AEventColorRed  _eventRedHandler;
    }
    class TrafficLigtsSubscriber
    {
        TrafficLigtsPublishert _objLigtsPublishert=null;

        public void EventAddLigts(TrafficLigtsPublishert _objLigtsPublishert)
        {
                //_objLigtsPublishert.AevenrRed+= 
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
        
        }
    }
}
