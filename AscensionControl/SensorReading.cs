using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;

namespace AscensionControl
{
    [Serializable()]
    public class Sensor
    {
        public double x, y, z, pitch, roll, yaw, time;
        public int active;
        public ushort quality, button;
    }

    [Serializable()]
    public class SensorReading
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public Sensor[] sensors;
        public Study study;
        public Subject subject;
        public Session session;
        public Trial trial;
        public long recordnum = 0;
        public int caps_switch = 0;
        public double time = 0;

        public SensorReading(Study study, Subject subject, Session session, Trial trial, long recordnum, TrackerInterface.Record rec)
        {
            this.study = study;
            this.subject = subject;
            this.session = session;
            this.trial = trial;
            this.time = rec.time[0];

            sensors = new Sensor[32];

            for (int i = 0; i < sensors.Length; i++)
            {
                sensors[i] = new Sensor();
                sensors[i].active = rec.active[i];
                sensors[i].x = rec.x[i];
                sensors[i].y = rec.y[i];
                sensors[i].z = rec.z[i];
                sensors[i].pitch = rec.pitch[i];
                sensors[i].yaw = rec.yaw[i];
                sensors[i].roll = rec.roll[i];
                sensors[i].time = rec.time[i];
                if (this.time == 0)
                {
                    time = rec.time[i];
                }
                sensors[i].quality = rec.quality[i];
                sensors[i].button = rec.button[i];
            }
        }

        public void SetTrial(Trial trial)
        {
            this.trial = trial;
            this.session = trial.session;
            this.subject = session.subject;
            this.study = session.study;
        }

        public SensorReading(long recordnum, TrackerInterface.Record rec)
        {
            sensors = new Sensor[32];

            for ( int i = 0; i < sensors.Length;i++ )
            {
                sensors[i] = new Sensor();
                sensors[i].active = rec.active[i];
                sensors[i].x = rec.x[i];
                sensors[i].y = rec.y[i];
                sensors[i].z = rec.z[i];
                sensors[i].pitch = rec.pitch[i];
                sensors[i].yaw = rec.yaw[i];
                sensors[i].roll = rec.roll[i];
                sensors[i].time = rec.time[i];
                if (this.time == 0)
                {
                    time = rec.time[i];
                }
                sensors[i].quality = rec.quality[i];
                sensors[i].button = rec.button[i];
            }

        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < sensors.Length; i++)
            {
                if (sensors[i].active == 1)
                {
                    s += string.Format("SENSOR {0} | BUT: {8} | X: {1:0.00} | Y: {2:0.00} | Z: {3:0.00} | PITCH: {4:0.00} | ROLL: {5:0.00} | YAW: {6:0.00} | QUALITY: {7}\n",
                        i, sensors[i].x, sensors[i].y, sensors[i].z, sensors[i].pitch, sensors[i].roll, sensors[i].yaw, sensors[i].quality, sensors[i].button);
                }
                
            }
            if (sensors[0].active == 1 && sensors[1].active == 1)
            {
                double d = Math.Sqrt(Math.Pow(sensors[1].x - sensors[0].x, 2) + Math.Pow(sensors[1].y - sensors[0].y, 2) + Math.Pow(sensors[1].z - sensors[0].z, 2));
                s += string.Format("\nDistance between 0 and 1: {0}\n", d);
            }
            return s;
        }

        public string ToCSV() 
        {
            string s = "";

            for (int i = 0; i < sensors.Length; i++)
            {
                if (sensors[i].active == 1)
                {
                    s += string.Format("{0},{1:0.00},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7},",
                        i, sensors[i].x, sensors[i].y, sensors[i].z, sensors[i].pitch, sensors[i].roll, sensors[i].yaw, sensors[i].quality);
                }
            }
            return s;
        }

        public List<string> GetActiveSensors()
        {
            List<string> activeSensors = new List<string>();

            for (int i = 0; i < sensors.Length; i++)
            {
                if (sensors[i].active == 1)
                {
                    activeSensors.Add(i.ToString());
                }
            }
            return activeSensors;
        }

        public List<int> GetQualityScores()
        {
            List<int> qualityNumbers = new List<int>();

            for (int i = 0; i < sensors.Length; i++)
            {
                if (sensors[i].active == 1)
                {
                    qualityNumbers.Add(sensors.ElementAt(i).quality);
                }
            }
            return qualityNumbers;
        }
    }

    
}
