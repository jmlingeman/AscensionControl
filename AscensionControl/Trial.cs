using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MongoDB.Bson;
using MongoDB.Driver;
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
    public class Trial
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public string name;
        //public ConcurrentQueue<SensorReading> data;
        public Study study;
        public Subject subject;
        public Session session;

        public Trial() { }
        public Trial(string name, string time, Study study, Subject subject, Session session)
        {
            this.study = study;
            this.subject = subject;
            this.session = session;
            this.name = name;
            //this.data = new ConcurrentQueue<SensorReading>();
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
