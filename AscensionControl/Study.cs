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
    public class Study
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string name;
        public List<Subject> subjects;

        public Study(string name)
        {
            this.name = name;
            this.subjects = new List<Subject>();
        }

        public override string ToString()
        {
            return this.name;
        }

        ~Study()
        {
        }
    }
}
