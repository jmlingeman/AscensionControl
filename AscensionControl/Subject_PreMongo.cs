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
    public class Subject_PreMongo
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public string id;
        public string bdate;
        public string gender;
        public ObservableCollection<Session> sessions;
        public Study study;

        public Subject_PreMongo() { }
        public Subject_PreMongo(string id, string bdate, string gender, Study study)
        {
            this.study = study;
            this.id = id;
            this.bdate = bdate;
            this.gender = gender;
            this.sessions = new ObservableCollection<Session>();
        }

        public override string ToString()
        {
            return this.id;
        }

    }
}
