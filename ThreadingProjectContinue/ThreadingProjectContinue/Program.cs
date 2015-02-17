﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ThreadingProjectContinue
{
    struct Param {
        public int msec;
        public string name;
        Thread t;
        public Param(int msec, string name, Thread t) {
            this.msec = msec;
            this.name = name;
            this.t = t;
        }
        public int Msec { get {
            return msec;
        }}

        public string Name {
            get {
            return name;   
            }
        }
        public Thread T { get {
            return t;
        } }
    }
    class Program
    {

        static void Main(string[] args)
        {


            List<Thread> thr = new List<Thread>();
            for (int i = 0; i < 4; i++)
            {
                thr.Add(new Thread(Text));
            }

            thr[0].Priority = ThreadPriority.BelowNormal;
            thr[1].Priority = ThreadPriority.Highest;
            thr[2].Priority = ThreadPriority.Lowest;
            thr[3].Priority = ThreadPriority.Normal;

            int index = 0;
            Random r = new Random();

            foreach (Thread item in thr)
            {
                Param p = new Param(r.Next(1000,4000), "name -"+ index.ToString(), item);

                item.Start(p);
                index++;
            }
            //foreach (Thread item in thr)
            //{
            //    item.Join();
            //}
        }

        static void Text(object obj) {
            Param p = (Param)obj;
            Console.WriteLine("Thread ="+p.Name+" time -"+ p.Msec);
            p.T.Join();
        }


    }
}
