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

        public SensorReading(Study study, Subject subject, Session session, Trial trial, long recordnum, TrackerInterface.Record rec)
        {
            this.study = study;
            this.subject = subject;
            this.session = session;
            this.trial = trial;

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
                sensors[i].quality = rec.quality[i];
                sensors[i].button = rec.button[i];
            }
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
                    s += string.Format("SENSOR {0} | X: {1:0.00} | Y: {2:0.00} | Z: {3:0.00} | PITCH: {4:0.00} | ROLL: {5:0.00} | YAW: {6:0.00} | QUALITY: {7}\n",
                        i, sensors[i].x, sensors[i].y, sensors[i].z, sensors[i].pitch, sensors[i].roll, sensors[i].yaw, sensors[i].quality);
                }
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
    }

    
}
