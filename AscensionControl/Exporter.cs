using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AscensionControl
{
    public class Exporter
    {
        // Current file being processed for the exporter bar
        public string status = "";
        public int percent = 0;

        // Load the exporter with the current study
        public Exporter()
        {
        }

        // This function will return a list of all of the times that the sync key was hit
        public List<int> FindSyncTimes(DatabaseControl db, Study study, Subject sub, Session sess)
        {
            List<int> times = new List<int>();

            return times;
        }

        public void ExportStudyToMultipleFiles(DatabaseControl db, Study study, string directory) 
        {

            string header = "StudyName,SubjectID,SessionName,SessionDate,TrialName,SessionSync1.Onset,SessionSync1.Offset,SessionSync2.Onset,SessionSync2.Offset,";

            for (int i = 0; i < 15; i++)
            {
                header += string.Format("Sensor{0}.ID,Sensor{0}.Time,Sensor{0}.Switch,Sensor{0}.X,Sensor{0}.Y,Sensor{0}.Z,Sensor{0}.Pitch,Sensor{0}.Roll,Sensor{0}.Yaw,Sensor{0}.quality,", i);
            }


            foreach (Subject sub in db.GetSubjects(study))
            {
                foreach (Session sess in db.GetSessions(sub))
                {
                    foreach (Trial trial in db.GetTrials(sess))
                    {
                        Console.WriteLine("Dumping trial : " + trial.name);
                        string filename = directory + "\\" + study.name + "-" + sub.id + "-" + sess.name + "-" + trial.name + ".csv";
                        status = string.Format("{0} - {1} - {2} - {3}", study.name, sub.id, sess.name, trial.name);

                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filename))
                        {
                            file.Write(header + "\n");

                            int total = db.GetSensorReadings(trial).Count();
                            int count = 0;
                            foreach (SensorReading pt in db.GetSensorReadings(trial))
                            {
                                count++;
                                percent = Convert.ToInt32(Math.Ceiling((float)count / (float)total * 100.0));
                                Sensor[] sensors = pt.sensors;
                                

                                // Append study/sub/sess/trial data
                                file.Write(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", study.name, sub.id, sess.name, sess.tdate, trial.name, sess.sync1_on, sess.sync1_off, sess.sync2_on, sess.sync2_off));
                                for (int i = 0; i < sensors.Length; i++)
                                {
                                    if (sensors[i].active == 1)
                                    {
                                        // Append sensor data whether sensor is active or not
                                        file.Write(string.Format(",{0},{9},{1},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8}",
                                            i, sensors[i].button, sensors[i].x, sensors[i].y, sensors[i].z, sensors[i].pitch, sensors[i].roll, sensors[i].yaw, sensors[i].quality, sensors[i].time));
                                    }
                                    else
                                    {
                                        // If the sensor wasn't active then append a blank filler
                                        file.Write(",,,,,,,,,,");
                                    }
                                }
                                file.Write("\n");
                            }
                        }
                        percent = 0;
                    }
                }
            }
            
        }

        public void ExportSubjectToMultipleFiles(DatabaseControl db, Study study, Subject subject, string directory)
        {
            string header = "StudyName,SubjectID,SessionName,SessionDate,TrialName,SessionSync1.Onset,SessionSync1.Offset,SessionSync2.Onset,SessionSync2.Offset,";

            for (int i = 0; i < 15; i++)
            {
                header += string.Format("Sensor{0}.ID,Sensor{0}.Time,Sensor{0}.Switch,Sensor{0}.X,Sensor{0}.Y,Sensor{0}.Z,Sensor{0}.Pitch,Sensor{0}.Roll,Sensor{0}.Yaw,Sensor{0}.quality,", i);
            }


                foreach (Session sess in db.GetSessions(subject))
                {
                    foreach (Trial trial in db.GetTrials(sess))
                    {
                        Console.WriteLine("Dumping trial : " + trial.name);
                        string filename = directory + "\\" + study.name + "-" + subject.id + "-" + sess.name + "-" + trial.name + ".csv";
                        status = string.Format("{0} - {1} - {2} - {3}", study.name, subject.id, sess.name, trial.name);
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filename))
                        {
                            file.Write(header + "\n");
                            int total = db.GetSensorReadings(trial).Count();
                            int count = 0;
                            foreach (SensorReading pt in db.GetSensorReadings(trial))
                            {
                                count++;
                                percent = Convert.ToInt32(Math.Ceiling((float)count / (float)total * 100.0));

                                Sensor[] sensors = pt.sensors;


                                // Append study/sub/sess/trial data
                                file.Write(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", study.name, subject.id, sess.name, sess.tdate, trial.name, sess.sync1_on, sess.sync1_off, sess.sync2_on, sess.sync2_off));
                                for (int i = 0; i < sensors.Length; i++)
                                {
                                    if (sensors[i].active == 1)
                                    {
                                        // Append sensor data whether sensor is active or not
                                        file.Write(string.Format(",{0},{9},{1},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8}",
                                            i, sensors[i].button, sensors[i].x, sensors[i].y, sensors[i].z, sensors[i].pitch, sensors[i].roll, sensors[i].yaw, sensors[i].quality, sensors[i].time));
                                    }
                                    else
                                    {
                                        // If the sensor wasn't active then append a blank filler
                                        file.Write(",,,,,,,,,,");
                                    }
                                }
                                file.Write("\n");
                            }
                        }
                        percent = 0;
                    }
                }
            

        }

        public void ExportStudyToCSVOneFile(DatabaseControl db, Study study, string filename)
        {

            string header = "StudyName,SubjectID,SessionName,SessionDate,TrialName,SessionSync1.Onset,SessionSync1.Offset,SessionSync2.Onset,SessionSync2.Offset,";

            for (int i = 0; i < 15; i++)
            {
                header += string.Format("Sensor{0}.ID,Sensor{0}.Time,Sensor{0}.Switch,Sensor{0}.X,Sensor{0}.Y,Sensor{0}.Z,Sensor{0}.Pitch,Sensor{0}.Roll,Sensor{0}.Yaw,Sensor{0}.quality,", i);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filename))
            {
           
                file.Write(header + "\n");
                foreach (Subject sub in db.GetSubjects(study))
                {
                    foreach (Session sess in db.GetSessions(sub))
                    {
                        foreach (Trial trial in db.GetTrials(sess))
                        {
                                Console.WriteLine("Dumping trial : " + trial.name);
                                status = string.Format("{0} - {1} - {2} - {3}", study.name, sub.id, sess.name, trial.name);

                                int total = db.GetSensorReadings(trial).Count();
                                int count = 0;
                                foreach (SensorReading pt in db.GetSensorReadings(trial))
                                {
                                    count++;
                                    percent = Convert.ToInt32(Math.Ceiling((float)count / (float)total * 100.0));

                                    Sensor[] sensors = pt.sensors;


                                    // Append study/sub/sess/trial data
                                    file.Write(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", study.name, sub.id, sess.name, sess.tdate, trial.name, sess.sync1_on, sess.sync1_off, sess.sync2_on, sess.sync2_off));
                                    for (int i = 0; i < sensors.Length; i++)
                                    {
                                        if (sensors[i].active == 1)
                                        {
                                            // Append sensor data whether sensor is active or not
                                            file.Write(string.Format(",{0},{9},{1},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8}",
                                                i, sensors[i].button, sensors[i].x, sensors[i].y, sensors[i].z, sensors[i].pitch, sensors[i].roll, sensors[i].yaw, sensors[i].quality, sensors[i].time));
                                        }
                                        else
                                        {
                                            // If the sensor wasn't active then append a blank filler
                                            file.Write(",,,,,,,,,,");
                                        }
                                    }
                                    file.Write("\n");
                                }
                                percent = 0;
                            }
                        }
                    }
                }

        }


        public void ExportSubjectToCSVOneFile(DatabaseControl db, Study study, Subject subject, string filename)
        {

            string header = "StudyName,SubjectID,SessionName,SessionDate,TrialName,SessionSync1.Onset,SessionSync1.Offset,SessionSync2.Onset,SessionSync2.Offset,";

            for (int i = 0; i < 15; i++)
            {
                header += string.Format("Sensor{0}.ID,Sensor{0}.Time,Sensor{0}.Switch,Sensor{0}.X,Sensor{0}.Y,Sensor{0}.Z,Sensor{0}.Pitch,Sensor{0}.Roll,Sensor{0}.Yaw,Sensor{0}.quality,", i);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filename))
            {
                file.Write(header + "\n");
                    foreach (Session sess in db.GetSessions(subject))
                    {
                        foreach (Trial trial in db.GetTrials(sess))
                        {
                            Console.WriteLine("Dumping trial : " + trial.name);
                            status = string.Format("{0} - {1} - {2} - {3}", study.name, subject.id, sess.name, trial.name);


                            int total = db.GetSensorReadings(trial).Count();
                            int count = 0;
                            foreach (SensorReading pt in db.GetSensorReadings(trial))
                            {
                                count++;
                                percent = Convert.ToInt32(Math.Ceiling((float)count / (float)total * 100.0));

                                Sensor[] sensors = pt.sensors;


                                // Append study/sub/sess/trial data
                                file.Write(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", study.name, subject.id, sess.name, sess.tdate, trial.name, sess.sync1_on, sess.sync1_off, sess.sync2_on, sess.sync2_off));
                                for (int i = 0; i < sensors.Length; i++)
                                {
                                    if (sensors[i].active == 1)
                                    {
                                        // Append sensor data whether sensor is active or not
                                        file.Write(string.Format(",{0},{9},{1},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8}",
                                            i, sensors[i].button, sensors[i].x, sensors[i].y, sensors[i].z, sensors[i].pitch, sensors[i].roll, sensors[i].yaw, sensors[i].quality, sensors[i].time));
                                    }
                                    else
                                    {
                                        // If the sensor wasn't active then append a blank filler
                                        file.Write(",,,,,,,,,,");
                                    }
                                }
                                file.Write("\n");
                            }
                            percent = 0;
                        }
                    }
                
            }

        }
    }
}
