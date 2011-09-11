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

        public Session() { }
        public Session(string name, string tdate, Study study, Subject subject)
        {
            this.study = study;
            this.subject = subject;
            this.name = name;
            this.tdate = tdate;
            //this.trials = new ObservableCollection<Trial>();
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
