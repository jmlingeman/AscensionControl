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
        DatabaseControl database;
        Trial trial;

        public Recorder(DatabaseControl database)
        {
            this.database = database;
            this.running = false;
        }

        public void Start(TrackerInterface tracker, Trial trial)
        {
            this.tracker = tracker;

            this.trial = trial;

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
                rec.SetTrial(trial);

                if (MainInterface.caps_switch == 1)
                {
                    rec.caps_switch = 1;
                }
                
                
                database.AddSensorReading(rec);
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

        public void NextTrial(Trial trial)
        {
            this.trial = trial;
        }
    }
}
