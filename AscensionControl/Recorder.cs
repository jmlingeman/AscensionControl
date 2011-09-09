using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;


namespace AscensionControl
{
    class Recorder
    {
        public bool running = false;
        ConcurrentQueue<SensorReading> data;
        TrackerInterface tracker;

        public Recorder()
        {
            this.running = false;
        }

        public void Start(TrackerInterface tracker, Trial trial)
        {
            this.tracker = tracker;

            this.data = trial.data;

            this.running = true;

            Thread getThread = new Thread(new ThreadStart(CollectRecord));
            getThread.Start();
        }

        //public void Start(TrackerInterface tracker)
        //{
        //    this.tracker = tracker;

        //    this.running = true;

        //    Console.WriteLine("STARTED");
        //    Thread getThread = new Thread(new ThreadStart(CollectRecord));
        //    getThread.Start();
        //}

        public void CollectRecord()
        {
            SensorReading rec;
            while (running == true)
            {
                rec = tracker.GetRecord();

                if (MainInterface.caps_switch == 1)
                {
                    rec.caps_switch = 1;
                }
                
                data.Enqueue(rec);
            }
        }

        public void CollectRecord_NoSave()
        {
            SensorReading rec;
            while (running == true)
            {
                rec = tracker.GetRecord();
                
            }
        }


        public void Stop()
        {
            this.running = false;
            Console.WriteLine("STOPPED, recorded {0} frames!", data.Count);
        }
    }
}
