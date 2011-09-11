using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AscensionControl
{
    class Exporter
    {
        Study study;
        // Load the exporter with the current study
        public Exporter()
        {
        }

        public void ExportStudyToCSV(DatabaseControl db, Study study, string filename) 
        {
            string s = "";
            string header = "StudyName,SessionName,SessionDate,TrialName";

            for (int i = 0; i < 15; i++)
            {
                header += string.Format("Sensor{0}.ID,Sensor{0}.X,Sensor{0}.Y,Sensor{0}.Z,Sensor{0}.Pitch,Sensor{0}.Roll,Sensor{0}.yaw,Sensor{0}.quality", i);
            }

            foreach (Subject sub in db.GetSubjects(study))
            {
                foreach (Session sess in db.GetSessions(sub))
                {
                    foreach (Trial trial in db.GetTrials(sess))
                    {
                        s += header + "\n";
                        foreach (SensorReading pt in db.GetSensorReadings(trial))
                        {
                            Sensor[] sensors = pt.sensors;

                            // Append study/sub/sess/trial data
                            s += string.Format("{0},{1},{2},{3}", study.name, sess.name, sess.tdate, trial.name);
                            for (int i = 0; i < sensors.Length; i++)
                            {
                                if (sensors[i].active == 1)
                                {
                                    // Append sensor data whether sensor is active or not
                                    s += string.Format(",{0},{1:0.00},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7}",
                                        i, sensors[i].x, sensors[i].y, sensors[i].z, sensors[i].pitch, sensors[i].roll, sensors[i].yaw, sensors[i].quality);
                                }
                                else
                                {
                                    // If the sensor wasn't active then append a blank filler
                                    s += ",,,,,,,,";
                                }
                            }
                            s += "\n";
                        }
                    }
                }
            }
            System.IO.File.WriteAllText(filename, s);
        }
    }
}
