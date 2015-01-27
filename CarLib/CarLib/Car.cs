using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Car
    {              
        public bool iStarted { private set;get;}
        public bool isSeatBeltWeared { private set; get; }
        public int Speed { private set;get;}
        public int Transmission { private set; get; }
        public int Fuel { private set; get; }
        public bool isClutchPushed { private set; get; }

        public Car()
        {
            this.Speed = 0;
            this.Transmission = 0;
            this.Fuel = 0;
            this.isSeatBeltWeared = false;
        }

        public void WearSeatBelt(){
            this.isSeatBeltWeared = true;
        }
        public void StartEngine()
        {
            if (this.iStarted == false)
                this.iStarted = true;
        }
        public void StopEngine()
        {
            if(this.iStarted == true)
                this.iStarted = false;
        }

        public void increaseTransmission()
        {
            if (this.iStarted == true & this.isClutchPushed == true) {
                this.Transmission++;
            }
        }

        public void decreaseTransmission()
        {
            if (this.iStarted == true & this.Transmission > 0 & this.isClutchPushed == true) {
                this.Transmission--;
            }
        }

        public void pushClutch(){
            this.isClutchPushed = true;
        }

        public void pushGas(){
            if (this.iStarted == true & this.Transmission > 0 & this.Fuel > 0 & this.isClutchPushed == false) {
                this.Speed += (Transmission * 5);
            }
        }

        public void pushBrake()
        {
            if (this.iStarted == true & this.Transmission > 0 & this.Speed > 0)
                this.Speed --;
        }

        public void Refuel(int howMuchFuel)
        { 
            this.Fuel += howMuchFuel;
        }
        public void ShowSpeed() {
            Console.WriteLine("\nSpeed:" + this.Speed);
        }

        public override string ToString()
        {
            return "Car status:\nEngine : " + this.iStarted + "\nTransmission: " + this.Transmission + "\nSpeed : " + this.Speed + "\nFuel :" +this.Fuel;
        }
    }
