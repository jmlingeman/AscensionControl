using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Wrappers;

namespace AscensionControl
{
    public class DatabaseControl
    {
        MongoServer server;
        MongoDatabase database;
        MongoCollection<Study> studies_collection;
        MongoCollection<Subject> subject_collection;
        MongoCollection<Session> session_collection;
        MongoCollection<Trial> trial_collection;
        MongoCollection<SensorReading> sensor_readings_collection;
        public DatabaseControl() 
        {
            // Connect to MongoDB
            this.server = MongoServer.Create("mongodb://localhost/");
            Console.WriteLine("Connection to MongoDB successful");
            this.database = server.GetDatabase("ascension");
            this.sensor_readings_collection = this.database.GetCollection<SensorReading>("sensorreadings");
            this.studies_collection = this.database.GetCollection<Study>("studies");
            this.subject_collection = this.database.GetCollection<Subject>("subjects");
            this.session_collection = this.database.GetCollection<Session>("sessions");
            this.

            ConvertDB("AscensionControl_Conv.dat");
            Console.WriteLine("Getting study from DB");
            ObservableCollection<Study> studies = GetStudies();
            foreach (Study study in studies)
            {
                Console.WriteLine(study.name);
            }
            //Console.WriteLine("Finished.");
        }

        public void ConvertDB(string filename)
        {
            Console.WriteLine("Beginning conversion of DB to Mongo");
            ObservableCollection<Study> studies = Load(filename);
            Console.WriteLine("Creating Database from file");
            foreach (Study study in studies) 
            {
                this.studies_collection.Insert<Study>(study);
                foreach (Subject subject in study.subjects)
                {
                    foreach (Session session in subject.sessions)
                    {
                        foreach (Trial trial in session.trials)
                        {
                            foreach (SensorReading sr in trial.data)
                            {
                                sr.study = study;
                                sr.subject = subject;
                                sr.session = session;
                                sr.trial = trial;

                                this.sensor_readings_collection.Insert<SensorReading>(sr);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Finished conversion of DB to Mongo");
        }

        public ObservableCollection<Study> GetStudies()
        {
            ObservableCollection<Study> studies = new ObservableCollection<Study>();
            var query = new QueryDocument();
            Study s = new Study("Testing");
            this.studies_collection.Insert<Study>(s);
            foreach (Study study in studies_collection.Find(query))
            {
                studies.Add(study);
                var study_query = Query.And(
                                    Query.EQ("study._Id", study._id),
                                    Query.EQ("trial._Id", study.subjects.ElementAt(0).sessions.ElementAt(0).trials.ElementAt(0)._Id)
                                    );
                SensorReading r = this.sensor_readings_collection.FindOne(query);
                Console.WriteLine(r.study.name, r.trial.name);
            }
            return studies;
        }
        

        public void Insert(SensorReading sr)
        {
            
        }

        public void Save()
        {
            //Save("AscensionControl.dat");
        }
        public void Save(string filename)
        {
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, MainInterface.studies);
                }
            }
            catch (IOException)
            {
            }
        }

        public ObservableCollection<Study> Load()
        {
            //Console.WriteLine("OPENING DATABASE...");
            return Load("AscensionControl.dat");
        }
        public ObservableCollection<Study> Load(string filename) 
        {
            ObservableCollection<Study> studies = new ObservableCollection<Study>();
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var loaded_studies = (ObservableCollection<Study>)bin.Deserialize(stream);
                    studies = loaded_studies;
                    return studies;
                }
            }
            catch (IOException)
            {
                return studies;
            }
        }
    }
}
