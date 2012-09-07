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
        System.IO.StreamWriter logfile;

        public DatabaseControl() 
        {
            // Connect to MongoDB
            this.server = MongoServer.Create("mongodb://localhost/?socketTimeoutMS=300000");
            Console.WriteLine("Connection to MongoDB successful");
            this.database = server.GetDatabase("ascension");
            this.sensor_readings_collection = this.database.GetCollection<SensorReading>("sensorreadings");
            this.studies_collection = this.database.GetCollection<Study>("studies");
            this.subject_collection = this.database.GetCollection<Subject>("subjects");
            this.session_collection = this.database.GetCollection<Session>("sessions");
            this.trial_collection = this.database.GetCollection<Trial>("trials");

            // For printing
            this.sensor_readings_collection.EnsureIndex("study._id", "subject._id", "session._id", "trial._id", "time");

            // For deleting
            this.sensor_readings_collection.EnsureIndex("study._id", "subject._id", "session._id", "trial._id");

            //ConvertDB("AscensionControl.dat");
            Console.WriteLine("Getting study from DB");
            ObservableCollection<Study> studies = GetStudies();
            foreach (Study study in studies)
            {
                Console.WriteLine(study.name);
            }

            string header = "StudyName,SubjectID,SessionName,SessionDate,TrialName,SessionSync1.Onset,SessionSync1.Offset,SessionSync2.Onset,SessionSync2.Offset,";

            for (int i = 0; i < 16; i++)
            {
                header += string.Format("Sensor{0}.ID,Sensor{0}.Time,Sensor{0}.Switch,Sensor{0}.X,Sensor{0}.Y,Sensor{0}.Z,Sensor{0}.Pitch,Sensor{0}.Roll,Sensor{0}.yaw,Sensor{0}.quality,", i);
            }
            Console.WriteLine(header);

            Console.WriteLine("OPENING LOG FILE");
            if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\AscensionLog")) {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\AscensionLog");
            }
            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\AscensionLog\\";
            string filepath = ("AscensionLog-" + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString() + ".csv").Replace(":","_").Replace("/","-");
            Console.WriteLine(filepath);
                logfile = new System.IO.StreamWriter(folderpath + filepath);
                logfile.WriteLine(header);
                Console.WriteLine("CREATED LOG FILE.");
            

            //Console.WriteLine("UPDATING TIMESTAMPS...");
            //updateTimestamps();
            //Console.WriteLine("FINISHED UPDATING TIMESTAMPS.");
        }

        //public void ConvertDB(string filename)
        //{
        //    Console.WriteLine("Beginning conversion of DB to Mongo");
        //    ObservableCollection<Study> studies = Load(filename);
        //    Console.WriteLine(studies);
        //    Console.WriteLine("Creating Database from file");
        //    foreach (Study study in studies) 
        //    {
        //        Console.WriteLine(study.name);
        //        this.studies_collection.Insert<Study>(study);
        //        foreach (Subject subject in study.subjects) 
        //        {
        //            this.subject_collection.Insert<Subject>(subject);
        //            foreach (Session session in subject.sessions)
        //            {
        //                this.session_collection.Insert<Session>(session);
        //                foreach (Trial trial in session.trials)
        //                {
        //                    this.trial_collection.Insert<Trial>(trial);
        //                    foreach (SensorReading sr in trial.data)
        //                    {
        //                        sr.study = study;
        //                        sr.subject = subject;
        //                        sr.session = session;
        //                        sr.trial = trial;

        //                        this.sensor_readings_collection.Insert<SensorReading>(sr);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    Console.WriteLine("Finished conversion of DB to Mongo");
        //}

        public ObservableCollection<Study> GetStudies()
        {
            ObservableCollection<Study> studies = new ObservableCollection<Study>();
            var query = new QueryDocument();
            foreach (Study study in studies_collection.Find(query))
            {
                studies.Add(study);
            }

            ObservableCollection<Study> studiesSort = new ObservableCollection<Study>(
                studies.OrderBy(study => study.name) 
                );
            return studiesSort;
        }

        public int GetStudyIndex(Study study)
        {
            ObservableCollection<Study> studies = GetStudies();
            for (int i = 0; i < studies.Count; i++)
            {
                Study s = studies[i];
                if (study._Id == s._Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void AddStudy(Study s)
        {
            studies_collection.Insert(s);
            Console.WriteLine("Study added.");
        }

        public void RemoveStudy(Study s)
        {
            var query = Query.Or(
                Query.EQ("_id", s._Id),
                Query.EQ("study._id", s._Id)
                );
            studies_collection.Remove(query);
            session_collection.Remove(query);
            subject_collection.Remove(query);
            trial_collection.Remove(query);
            sensor_readings_collection.Remove(query);
        }

        public ObservableCollection<Subject> GetSubjects(Study study)
        {
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            var query = Query.EQ("study._id", study._Id);
            foreach (Subject subject in subject_collection.Find(query))
            {
                subjects.Add(subject);
            }
            ObservableCollection<Subject> subjectsSort = new ObservableCollection<Subject>(
                subjects.OrderBy(subject => subject.id)
                );
            return subjectsSort;
        }

        public int GetSubjectIndex(Subject subject)
        {
            ObservableCollection<Subject> subjects = GetSubjects(subject.study);
            for (int i = 0; i < subjects.Count; i++)
            {
                Subject s = subjects[i];
                if (subject._Id == s._Id)
                {
                    Console.WriteLine("Found subject at {0}.", i);
                    return i;
                }
            }
            Console.WriteLine("ERROR: Could not find subject.");
            return -1;
        }

        public void AddSubject(Subject s)
        {
            subject_collection.Insert(s);
        }

        public void RemoveSubject(Subject s)
        {
            var query = Query.Or(
                Query.EQ("_id", s._Id),
                Query.EQ("subject._id", s._Id)
                );
            subject_collection.Remove(query);
            session_collection.Remove(query);
            trial_collection.Remove(query);
            sensor_readings_collection.Remove(query);
        }

        public ObservableCollection<Session> GetSessions(Subject subject)
        {
            ObservableCollection<Session> sessions = new ObservableCollection<Session>();
            var query = Query.And(
                Query.EQ("study._id", subject.study._Id),
                Query.EQ("subject._id", subject._Id)
                );
            foreach (Session session in session_collection.Find(query))
            {
                sessions.Add(session);
            }
            ObservableCollection<Session> sessionsSort = new ObservableCollection<Session>(
                sessions.OrderBy(session => session.name)
                );
            return sessions;
        }

        public int GetSessionIndex(Session session)
        {
            ObservableCollection<Session> sessions = GetSessions(session.subject);
            for (int i = 0; i < sessions.Count; i++)
            {
                Session s = sessions[i];
                if (session._Id == s._Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void AddSession(Session s)
        {
            session_collection.Insert(s);
        }

        public void RemoveSession(Session s)
        {
            var query = Query.Or(
                Query.EQ("_id", s._Id),
                Query.EQ("session._id", s._Id)
                );
            session_collection.Remove(query);
            trial_collection.Remove(query);
            sensor_readings_collection.Remove(query);
        }

        public void UpdateSession(Session s)
        {
            session_collection.Save(s);
        }

        public ObservableCollection<Trial> GetTrials(Session session)
        {
            ObservableCollection<Trial> trials = new ObservableCollection<Trial>();
            var query = Query.And(
                Query.EQ("study._id", session.study._Id),
                Query.EQ("subject._id", session.subject._Id),
                Query.EQ("session._id", session._Id)
                );
            foreach (Trial trial in trial_collection.Find(query))
            {
                trials.Add(trial);
            }
            ObservableCollection<Trial> trialsSort = new ObservableCollection<Trial>(
                trials.OrderBy(trial => trial.name)
                );
            return trials;
        }

        public int GetTrialIndex(Trial trial)
        {
            ObservableCollection<Trial> trials = GetTrials(trial.session);
            for (int i = 0; i < trials.Count; i++)
            {
                Trial s = trials[i];
                if (trial._Id == s._Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void AddTrial(Trial t)
        {
            trial_collection.Insert(t);
        }

        public void RemoveTrial(Trial trial)
        {
            var query = Query.And(
                Query.EQ("study._id", trial.study._Id),
                Query.EQ("subject._id", trial.subject._Id),
                Query.EQ("session._id", trial.session._Id),
                Query.EQ("trial._id", trial._Id)
                );
            trial_collection.Remove(query);
            sensor_readings_collection.Remove(query);
        }

        public MongoCursor<SensorReading> GetSensorReadings(Trial trial)
        {
            ObservableCollection<SensorReading> sensor_readings = new ObservableCollection<SensorReading>();
            var query = Query.And(
                Query.EQ("study._id", trial.study._Id),
                Query.EQ("subject._id", trial.subject._Id),
                Query.EQ("session._id", trial.session._Id),
                Query.EQ("trial._id", trial._Id)
                );

            Console.WriteLine("Getting sensor readings");
            return sensor_readings_collection.Find(query).SetSortOrder(SortBy.Ascending("time"));
            //foreach (SensorReading sr in sensor_readings_collection.Find(query))
            //{
            //    sensor_readings.Add(sr);
            //}
            //ObservableCollection<SensorReading> sensor_readingsSort = new ObservableCollection<SensorReading>(
            //    sensor_readings.OrderBy(s => s.recordnum)
            //    );
            //return sensor_readings;
        }

        public void AddSensorReading(SensorReading s)
        {
            

            Sensor[] sensors = s.sensors;
            Study study = s.study;
            Subject sub = s.subject;
            Session sess = s.session;
            Trial trial = s.trial;

            // Append study/sub/sess/trial data
            logfile.Write(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", study.name, sub.id, sess.name, sess.tdate, trial.name, sess.sync1_on, sess.sync1_off, sess.sync2_on, sess.sync2_off));
            for (int i = 0; i < sensors.Length; i++)
            {
                if (sensors[i].active == 1)
                {
                    // Append sensor data whether sensor is active or not
                    logfile.Write(string.Format(",{0},{9},{1},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8}",
                        i, sensors[i].button, sensors[i].x, sensors[i].y, sensors[i].z, sensors[i].pitch, sensors[i].roll, sensors[i].yaw, sensors[i].quality, sensors[i].time));
                }
                else
                {
                    // If the sensor wasn't active then append a blank filler
                    logfile.Write(",,,,,,,,,,");
                }
            }
            logfile.Write("\n");

            sensor_readings_collection.Insert(s);
        }

        public void RemoveSensorReading(SensorReading s)
        {
            var query = Query.And(
                Query.EQ("study._id", s.study._Id),
                Query.EQ("subject._id", s.subject._Id),
                Query.EQ("session._id", s.session._Id),
                Query.EQ("trial._id", s.trial._Id)
            );
            sensor_readings_collection.Remove(query);
        }

        public void Save()
        {
            Save("AscensionControl.dat");
        }
        public void Save(string filename)
        {
            //try
            //{
            //    using (Stream stream = File.Open(filename, FileMode.Create))
            //    {
            //        BinaryFormatter bin = new BinaryFormatter();
            //        bin.Serialize(stream, MainInterface.studies);
            //    }
            //}
            //catch (IOException)
            //{
            //}
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

        public void updateTimestamps()
        {
            foreach(Study study in GetStudies() ) {
                foreach (Subject subj in GetSubjects(study))
                {
                    foreach (Session sess in GetSessions(subj))
                    {
                        foreach (Trial trial in GetTrials(sess))
                        {
                            foreach (SensorReading sr in GetSensorReadings(trial))
                            {
                                sr.time = sr.sensors[0].time;
                                sensor_readings_collection.Save(sr);
                            }
                        }
                    }
                }
            }
        }

        public void updateIndexes()
        {
            //this.sensor_readings_collection.EnsureIndex(IndexKeys.Ascending("time"));
        }
    }
}
