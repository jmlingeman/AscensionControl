using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class Session
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public string name;
        public string tdate;
        //public ObservableCollection<Trial> trials;
        public Study study;
        public Subject subject;
        public double sync1_on;
        public double sync1_off;
        public double sync2_on;
        public double sync2_off;

        public Session() { }
        public Session(string name, string tdate, Study study, Subject subject)
        {
            this.study = study;
            this.subject = subject;
            this.name = name;
            this.tdate = tdate;
            this.sync1_on = -1;
            this.sync1_off = -1;
            this.sync2_on = -1;
            this.sync2_off = -1;
            //this.trials = new ObservableCollection<Trial>();
        }

        public void ResetSync()
        {
            this.sync1_on = -1;
            this.sync1_off = -1;
            this.sync2_off = -1;
            this.sync2_on = -1;
        }

        public void SetSync(double time, bool on) 
        {
            if (on == true)
            {
                if (this.sync1_on == -1)
                {
                    this.sync1_on = time;
                }
                else if (this.sync2_on == -1)
                {
                    this.sync2_on = time;
                }
                else
                {
                    this.sync1_on = -1;
                    this.sync2_on = -1;
                }
            }
            else if (on == false)
            {
                if (this.sync1_off == -1)
                {
                    this.sync1_off = time;
                }
                else if (this.sync2_off == -1)
                {
                    this.sync2_off = time;
                }
                else
                {
                    this.sync1_off = -1;
                    this.sync2_off = -1;
                }
            }
            Console.WriteLine(this.sync1_on);


        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
