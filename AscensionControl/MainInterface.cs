﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.ObjectModel;

namespace AscensionControl
{
    public partial class MainInterface : Form
    {
        public static ObservableCollection<Study> studies = new ObservableCollection<Study>();
        public Study currentStudy;
        public Subject currentSubject;
        public Session currentSession;
        public Trial currentTrial;
        Recorder recorder;
        public TrackerInterface trackerinterface;
        public List<bool> blankList;
        public DatabaseControl database;
        public static int caps_switch;

        public MainInterface()
        {
            InitializeComponent();
            database = new DatabaseControl();

            blankList = new List<bool>();

            studies = database.Load();
            currentStudy = new Study("init");
            studyDisplay.DataSource = studies;

            currentSubject = new Subject("init", "init", "init");
            subjectDisplay.DataSource = currentStudy.subjects;

            currentSession = new Session("init", "init");
            sessionDisplay.DataSource = currentSubject.sessions;

            currentTrial = new Trial("init", "init");
            trialDisplay.DataSource = currentSession.trials;

            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void addNewStudy_Click(object sender, EventArgs e)
        {
            string value = "";
            DialogResult result = MainInterface.InputBox("New Study", "New study name:", ref value);
            if ( result == DialogResult.OK && value != "")
            {
                currentStudy = new Study(value);
                studies.Add(currentStudy);

                studyDisplay.DataSource = null;
                studyDisplay.DataSource = studies;
                studyDisplay.ClearSelected();
                studyDisplay.SetSelected(studies.IndexOf(currentStudy), true);

                Console.WriteLine(value);
                database.Save();
            }
            else if (result == DialogResult.OK)
            {
                MessageBox.Show("Invalid study name.");
            }

        }



        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
          Form form = new Form();
          Label label = new Label();
          TextBox textBox = new TextBox();
          Button buttonOk = new Button();
          Button buttonCancel = new Button();

          form.Text = title;
          label.Text = promptText;
          textBox.Text = value;

          buttonOk.Text = "OK";
          buttonCancel.Text = "Cancel";
          buttonOk.DialogResult = DialogResult.OK;
          buttonCancel.DialogResult = DialogResult.Cancel;

          label.SetBounds(9, 20, 372, 13);
          textBox.SetBounds(12, 36, 372, 20);
          buttonOk.SetBounds(228, 72, 75, 23);
          buttonCancel.SetBounds(309, 72, 75, 23);

          label.AutoSize = true;
          textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
          buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
          buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

          form.ClientSize = new Size(396, 107);
          form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
          form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
          form.FormBorderStyle = FormBorderStyle.FixedDialog;
          form.StartPosition = FormStartPosition.CenterScreen;
          form.MinimizeBox = false;
          form.MaximizeBox = false;
          form.AcceptButton = buttonOk;
          form.CancelButton = buttonCancel;

          DialogResult dialogResult = form.ShowDialog();
          value = textBox.Text;
          return dialogResult;
        }

        public static DialogResult InputBox2(string title, string promptText1, string promptText2, ref List<string> values)
        {
            Form form = new Form();
            Label label1 = new Label();
            Label label2 = new Label();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label1.Text = promptText1;
            label2.Text = promptText2;
            textBox1.Text = "";
            textBox2.Text = "";

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label1.SetBounds(9, 20, 372, 13);
            textBox1.SetBounds(12, 36, 372, 20);

            label2.SetBounds(9, 60, 372, 13);
            textBox2.SetBounds(12, 76, 372, 20);

            buttonOk.SetBounds(228, 120, 75, 23);
            buttonCancel.SetBounds(309, 120, 75, 23);

            label1.AutoSize = true;
            label2.AutoSize = true;
            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 170);
            form.Controls.AddRange(new Control[] { label1, textBox1, label2, textBox2, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label2.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            values.Add(textBox1.Text);
            values.Add(textBox2.Text);
            return dialogResult;
        }

        public static DialogResult InputBox3(string title, string promptText1, string promptText2, string promptText3, ref List<string> values)
        {
            Form form = new Form();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label1.Text = promptText1;
            label2.Text = promptText2;
            label3.Text = promptText3;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label1.SetBounds(9, 20, 372, 13);
            textBox1.SetBounds(12, 36, 372, 20);

            label2.SetBounds(9, 60, 372, 13);
            textBox2.SetBounds(12, 76, 372, 20);

            label3.SetBounds(9, 100, 372, 13);
            textBox3.SetBounds(12, 116, 372, 20);

            buttonOk.SetBounds(228, 150, 75, 23);
            buttonCancel.SetBounds(309, 150, 75, 23);

            label1.AutoSize = true;
            label2.AutoSize = true;
            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 200);
            form.Controls.AddRange(new Control[] { label1, textBox1, label2, textBox2, label3, textBox3, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label2.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            values.Add(textBox1.Text);
            values.Add(textBox2.Text);
            values.Add(textBox3.Text);
            return dialogResult;
        }


        private void studyDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(studyDisplay.SelectedIndex);
            if (studyDisplay.SelectedIndex == -1)
            {
                studyDisplay.ClearSelected();
            }
            else
            {
                currentStudy = studies[studyDisplay.SelectedIndex];
                Console.WriteLine(currentStudy.ToString());

                // Refresh the data windows
                subjectDisplay.DataSource = currentStudy.subjects;
                ((CurrencyManager)subjectDisplay.BindingContext[subjectDisplay.DataSource]).Refresh();
                subjectDisplay.ClearSelected();

                sessionDisplay.DataSource = blankList;
                ((CurrencyManager)sessionDisplay.BindingContext[sessionDisplay.DataSource]).Refresh();
                //sessionDisplay.DataSource = null;
                //sessionDisplay.DataSource = currentSubject.sessions;
                //sessionDisplay.ClearSelected();

                trialDisplay.DataSource = blankList;
                ((CurrencyManager)trialDisplay.BindingContext[trialDisplay.DataSource]).Refresh();
                //trialDisplay.DataSource = null;
                //trialDisplay.DataSource = currentSession.trials;
                //trialDisplay.ClearSelected();
            }
        }

        private void removeStudy_Click(object sender, EventArgs e)
        {
            if (studyDisplay.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this study?", "Remove Study", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    currentStudy = studies[studyDisplay.SelectedIndex];
                    studies.Remove(currentStudy);
                    currentStudy = null;

                    studyDisplay.DataSource = null;
                    studyDisplay.DataSource = studies;
                }
            }
        }


        private void addNewSubject_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            if (studyDisplay.SelectedIndex > -1)
            {
                DialogResult result = MainInterface.InputBox3("New Subject", "New Subject ID:", "New Subject Birthdate:", "New Subject Gender:", ref values);
                if (result == DialogResult.OK && values.Count > 0)
                {
                    Subject s = new Subject(values[0], values[1], values[2]);
                    currentStudy.subjects.Add(s);

                    subjectDisplay.DataSource = null;
                    subjectDisplay.DataSource = currentStudy.subjects;
                    subjectDisplay.ClearSelected();
                    subjectDisplay.SetSelected(currentStudy.subjects.IndexOf(s), true);

                    Console.WriteLine(values);
                    database.Save();
                }
                else if (result == DialogResult.OK)
                {
                    MessageBox.Show("Invalid study name.");
                }
            }
        }

        private void removeSubject_Click(object sender, EventArgs e)
        {
            if (subjectDisplay.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this subject?", "Remove Subject", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    currentSubject = currentStudy.subjects[subjectDisplay.SelectedIndex];
                    currentStudy.subjects.Remove(currentSubject);
                    currentSubject = null;

                    subjectDisplay.DataSource = null;
                    subjectDisplay.DataSource = currentStudy.subjects;
                }
            }
        }

        private void loadTracker_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Attempting to start tracker...");
            trackerinterface = new TrackerInterface(6.0f);
            recorder = new Recorder();
            Console.WriteLine("Tracker initialized");
            startButton.Enabled = true;
            loadTracker.Enabled = false;
            unloadTracker.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Begin recording

            //currentTrial = new Trial("test");
            recorder.Start(trackerinterface, currentTrial);

            Console.WriteLine("Recording started.");

            startButton.Enabled = false;
            stopButton.Enabled = true;
            nextTrial.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Stop recording
            recorder.Stop();

            stopButton.Enabled = false;
            startButton.Enabled = true;
            nextTrial.Enabled = false;

            // Now save, just in case!
        }

        private void nextTrial_Click(object sender, EventArgs e)
        {
            // Make a new trial and start adding to that.  No interruption can be allowed here.
        }

        private void addNewSession_Click(object sender, EventArgs e)
        {
            string value = "";
            if (subjectDisplay.SelectedIndex > -1)
            {
                DialogResult result = MainInterface.InputBox("Create New Session", "Session Name:", ref value);
                if (result == DialogResult.OK)
                {
                    Session s = new Session(value, DateTime.Now.ToString("M/d/yyyy"));
                    currentSubject.sessions.Add(s);

                    sessionDisplay.DataSource = null;
                    sessionDisplay.DataSource = currentSubject.sessions;
                    ((CurrencyManager)sessionDisplay.BindingContext[sessionDisplay.DataSource]).Refresh();
                    sessionDisplay.ClearSelected();
                    sessionDisplay.SetSelected(currentSubject.sessions.IndexOf(s), true);

                    Console.WriteLine(value);
                    database.Save();
                }
            }
        }

        private void removeSession_Click(object sender, EventArgs e)
        {
            if (sessionDisplay.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this session?", "Remove Session", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    currentSession = currentSubject.sessions[sessionDisplay.SelectedIndex];
                    currentSubject.sessions.Remove(currentSession);
                    currentSession = null;

                    sessionDisplay.DataSource = null;
                    sessionDisplay.DataSource = currentSubject.sessions;
                }
            }
        }

        private void addTrial_Click(object sender, EventArgs e)
        {
            string value = "";
            if (sessionDisplay.SelectedIndex > -1)
            {
                DialogResult result = MainInterface.InputBox("Create New Trial", "Trial Name:", ref value);
                if (result == DialogResult.OK)
                {
                    Trial t = new Trial(value, DateTime.Now.ToString("H:mm:ss"));
                    currentSession.trials.Add(t);

                    trialDisplay.DataSource = null;
                    trialDisplay.DataSource = currentSession.trials;
                    trialDisplay.ClearSelected();
                    trialDisplay.SetSelected(currentSession.trials.IndexOf(t), true);

                    Console.WriteLine(value);
                    database.Save();
                }
            }
        }

        private void removeTrial_Click(object sender, EventArgs e)
        {
            if (sessionDisplay.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this trial?", "Remove Session", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    currentTrial = currentSession.trials[trialDisplay.SelectedIndex];
                    currentSession.trials.Remove(currentTrial);
                    currentSession = null;

                    trialDisplay.DataSource = null;
                    trialDisplay.DataSource = currentSession.trials;
                    database.Save();
                }
            }
        }

        private void subjectDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(subjectDisplay.SelectedIndex);
            if (subjectDisplay.SelectedIndex == -1)
            {
                subjectDisplay.ClearSelected();
            }
            else
            {
                currentSubject = currentStudy.subjects[subjectDisplay.SelectedIndex];
                Console.WriteLine(currentStudy.ToString());

                // Refresh the data windows
                sessionDisplay.DataSource = null;
                sessionDisplay.DataSource = currentSubject.sessions;
                //((CurrencyManager)sessionDisplay.BindingContext[sessionDisplay.DataSource]).Refresh();
                sessionDisplay.ClearSelected();

                trialDisplay.DataSource = blankList;
                ((CurrencyManager)trialDisplay.BindingContext[trialDisplay.DataSource]).Refresh();
                trialDisplay.ClearSelected();

            }
        }

        private void sessionDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(sessionDisplay.SelectedIndex);
            if (sessionDisplay.SelectedIndex == -1)
            {
                sessionDisplay.ClearSelected();
            }
            else
            {
                currentSession = currentSubject.sessions[sessionDisplay.SelectedIndex];
                Console.WriteLine(currentSession.ToString());

                // Refresh the data windows
                trialDisplay.DataSource = currentSession.trials;
                ((CurrencyManager)trialDisplay.BindingContext[trialDisplay.DataSource]).Refresh();
                trialDisplay.ClearSelected();
                //trialDisplay.DataSource = null;
                //trialDisplay.DataSource = currentSession.trials;
                //trialDisplay.ClearSelected();
            }
        }

        private void trialDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trialDisplay.SelectedIndex == -1)
            {
                trialDisplay.ClearSelected();
            }
            else
            {
                currentTrial = currentSession.trials[trialDisplay.SelectedIndex];
                Console.WriteLine(currentTrial.ToString());
                Console.WriteLine("This trial contains {0} frames of data!", currentTrial.data.Count);

            }
        }

        private void MainInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            database.Save();
        }
        
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                caps_switch = 1;
                Console.WriteLine("CAPS ON");
            }
            else
            {
                caps_switch = 0;
                Console.WriteLine("CAPS OFF");
            }
        }

        private void getSensors_Click(object sender, EventArgs e)
        {
            sensorInfo.Text = currentTrial.data.ElementAt(currentTrial.data.Count - 1).ToString();
        }

        private void ExportStudyButton_Click(object sender, EventArgs e)
        {
            Exporter exporter = new Exporter();
            exporter.ExportStudyToCSV( currentStudy,
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Printout.csv" );
        }







    }
}