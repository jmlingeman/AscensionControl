namespace AscensionControl
{
    partial class MainInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.loadTracker = new System.Windows.Forms.Button();
            this.unloadTracker = new System.Windows.Forms.Button();
            this.studyDisplay = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subjectDisplay = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trialDisplay = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addNewStudy = new System.Windows.Forms.Button();
            this.removeStudy = new System.Windows.Forms.Button();
            this.addNewSubject = new System.Windows.Forms.Button();
            this.removeSubject = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nextTrial = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.removeTrial = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ExportStudyButton = new System.Windows.Forms.Button();
            this.getSensors = new System.Windows.Forms.Button();
            this.sensorInfo = new System.Windows.Forms.RichTextBox();
            this.addTrial = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.sessionDisplay = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addNewSession = new System.Windows.Forms.Button();
            this.removeSession = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadTracker
            // 
            this.loadTracker.Location = new System.Drawing.Point(6, 6);
            this.loadTracker.Name = "loadTracker";
            this.loadTracker.Size = new System.Drawing.Size(114, 23);
            this.loadTracker.TabIndex = 0;
            this.loadTracker.Text = "Load Tracker";
            this.loadTracker.UseVisualStyleBackColor = true;
            this.loadTracker.Click += new System.EventHandler(this.loadTracker_Click);
            // 
            // unloadTracker
            // 
            this.unloadTracker.Enabled = false;
            this.unloadTracker.Location = new System.Drawing.Point(134, 6);
            this.unloadTracker.Name = "unloadTracker";
            this.unloadTracker.Size = new System.Drawing.Size(112, 23);
            this.unloadTracker.TabIndex = 1;
            this.unloadTracker.Text = "Unload Tracker";
            this.unloadTracker.UseVisualStyleBackColor = true;
            // 
            // studyDisplay
            // 
            this.studyDisplay.FormattingEnabled = true;
            this.studyDisplay.Location = new System.Drawing.Point(9, 48);
            this.studyDisplay.Name = "studyDisplay";
            this.studyDisplay.Size = new System.Drawing.Size(120, 173);
            this.studyDisplay.TabIndex = 2;
            this.studyDisplay.SelectedIndexChanged += new System.EventHandler(this.studyDisplay_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Study";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // subjectDisplay
            // 
            this.subjectDisplay.FormattingEnabled = true;
            this.subjectDisplay.Location = new System.Drawing.Point(135, 48);
            this.subjectDisplay.Name = "subjectDisplay";
            this.subjectDisplay.Size = new System.Drawing.Size(120, 173);
            this.subjectDisplay.TabIndex = 4;
            this.subjectDisplay.SelectedIndexChanged += new System.EventHandler(this.subjectDisplay_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subject";
            // 
            // trialDisplay
            // 
            this.trialDisplay.FormattingEnabled = true;
            this.trialDisplay.Location = new System.Drawing.Point(387, 48);
            this.trialDisplay.Name = "trialDisplay";
            this.trialDisplay.Size = new System.Drawing.Size(172, 173);
            this.trialDisplay.TabIndex = 6;
            this.trialDisplay.SelectedIndexChanged += new System.EventHandler(this.trialDisplay_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trial";
            // 
            // addNewStudy
            // 
            this.addNewStudy.Location = new System.Drawing.Point(9, 228);
            this.addNewStudy.Name = "addNewStudy";
            this.addNewStudy.Size = new System.Drawing.Size(120, 23);
            this.addNewStudy.TabIndex = 8;
            this.addNewStudy.Text = "Add New Study";
            this.addNewStudy.UseVisualStyleBackColor = true;
            this.addNewStudy.Click += new System.EventHandler(this.addNewStudy_Click);
            // 
            // removeStudy
            // 
            this.removeStudy.Location = new System.Drawing.Point(10, 258);
            this.removeStudy.Name = "removeStudy";
            this.removeStudy.Size = new System.Drawing.Size(119, 23);
            this.removeStudy.TabIndex = 9;
            this.removeStudy.Text = "Remove Study";
            this.removeStudy.UseVisualStyleBackColor = true;
            this.removeStudy.Click += new System.EventHandler(this.removeStudy_Click);
            // 
            // addNewSubject
            // 
            this.addNewSubject.Location = new System.Drawing.Point(135, 228);
            this.addNewSubject.Name = "addNewSubject";
            this.addNewSubject.Size = new System.Drawing.Size(120, 23);
            this.addNewSubject.TabIndex = 10;
            this.addNewSubject.Text = "Add New Subject";
            this.addNewSubject.UseVisualStyleBackColor = true;
            this.addNewSubject.Click += new System.EventHandler(this.addNewSubject_Click);
            // 
            // removeSubject
            // 
            this.removeSubject.Location = new System.Drawing.Point(135, 258);
            this.removeSubject.Name = "removeSubject";
            this.removeSubject.Size = new System.Drawing.Size(120, 23);
            this.removeSubject.TabIndex = 11;
            this.removeSubject.Text = "Remove Subject";
            this.removeSubject.UseVisualStyleBackColor = true;
            this.removeSubject.Click += new System.EventHandler(this.removeSubject_Click);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(964, 48);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(443, 421);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(965, 475);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(443, 156);
            this.chart2.TabIndex = 13;
            this.chart2.Text = "chart2";
            // 
            // nextTrial
            // 
            this.nextTrial.BackColor = System.Drawing.Color.DodgerBlue;
            this.nextTrial.Enabled = false;
            this.nextTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextTrial.Location = new System.Drawing.Point(1239, 637);
            this.nextTrial.Name = "nextTrial";
            this.nextTrial.Size = new System.Drawing.Size(168, 60);
            this.nextTrial.TabIndex = 14;
            this.nextTrial.Text = "Next Trial";
            this.nextTrial.UseVisualStyleBackColor = false;
            this.nextTrial.Click += new System.EventHandler(this.nextTrial_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1134, 673);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1134, 654);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Next Trial Name";
            // 
            // removeTrial
            // 
            this.removeTrial.Location = new System.Drawing.Point(387, 257);
            this.removeTrial.Name = "removeTrial";
            this.removeTrial.Size = new System.Drawing.Size(121, 23);
            this.removeTrial.TabIndex = 17;
            this.removeTrial.Text = "Remove Trial";
            this.removeTrial.UseVisualStyleBackColor = true;
            this.removeTrial.Click += new System.EventHandler(this.removeTrial_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(987, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Quality Numbers";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Sensor Information";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1422, 729);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.ExportStudyButton);
            this.tabPage1.Controls.Add(this.getSensors);
            this.tabPage1.Controls.Add(this.sensorInfo);
            this.tabPage1.Controls.Add(this.addTrial);
            this.tabPage1.Controls.Add(this.startButton);
            this.tabPage1.Controls.Add(this.stopButton);
            this.tabPage1.Controls.Add(this.sessionDisplay);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.addNewSession);
            this.tabPage1.Controls.Add(this.removeSession);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.chart2);
            this.tabPage1.Controls.Add(this.nextTrial);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.trialDisplay);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.studyDisplay);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.subjectDisplay);
            this.tabPage1.Controls.Add(this.removeTrial);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.addNewStudy);
            this.tabPage1.Controls.Add(this.removeStudy);
            this.tabPage1.Controls.Add(this.addNewSubject);
            this.tabPage1.Controls.Add(this.removeSubject);
            this.tabPage1.Controls.Add(this.loadTracker);
            this.tabPage1.Controls.Add(this.unloadTracker);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1414, 703);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(786, 207);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 47);
            this.button4.TabIndex = 34;
            this.button4.Text = "Export Current Trial";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(786, 154);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 47);
            this.button3.TabIndex = 33;
            this.button3.Text = "Export Current Session";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(786, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 47);
            this.button2.TabIndex = 32;
            this.button2.Text = "Export Current Subject";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ExportStudyButton
            // 
            this.ExportStudyButton.Location = new System.Drawing.Point(786, 48);
            this.ExportStudyButton.Name = "ExportStudyButton";
            this.ExportStudyButton.Size = new System.Drawing.Size(168, 47);
            this.ExportStudyButton.TabIndex = 31;
            this.ExportStudyButton.Text = "Export Current Study";
            this.ExportStudyButton.UseVisualStyleBackColor = true;
            this.ExportStudyButton.Click += new System.EventHandler(this.ExportStudyButton_Click);
            // 
            // getSensors
            // 
            this.getSensors.Location = new System.Drawing.Point(10, 296);
            this.getSensors.Name = "getSensors";
            this.getSensors.Size = new System.Drawing.Size(168, 47);
            this.getSensors.TabIndex = 30;
            this.getSensors.Text = "Get Current Sensor Data";
            this.getSensors.UseVisualStyleBackColor = true;
            this.getSensors.Click += new System.EventHandler(this.getSensors_Click);
            // 
            // sensorInfo
            // 
            this.sensorInfo.Location = new System.Drawing.Point(3, 372);
            this.sensorInfo.Name = "sensorInfo";
            this.sensorInfo.Size = new System.Drawing.Size(556, 325);
            this.sensorInfo.TabIndex = 29;
            this.sensorInfo.Text = "";
            // 
            // addTrial
            // 
            this.addTrial.Location = new System.Drawing.Point(387, 228);
            this.addTrial.Name = "addTrial";
            this.addTrial.Size = new System.Drawing.Size(121, 23);
            this.addTrial.TabIndex = 28;
            this.addTrial.Text = "Add Trial";
            this.addTrial.UseVisualStyleBackColor = true;
            this.addTrial.Click += new System.EventHandler(this.addTrial_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.YellowGreen;
            this.startButton.Enabled = false;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(786, 633);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(168, 60);
            this.startButton.TabIndex = 27;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Red;
            this.stopButton.Enabled = false;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Location = new System.Drawing.Point(960, 633);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(168, 60);
            this.stopButton.TabIndex = 26;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // sessionDisplay
            // 
            this.sessionDisplay.FormattingEnabled = true;
            this.sessionDisplay.Location = new System.Drawing.Point(261, 48);
            this.sessionDisplay.Name = "sessionDisplay";
            this.sessionDisplay.Size = new System.Drawing.Size(120, 173);
            this.sessionDisplay.TabIndex = 22;
            this.sessionDisplay.SelectedIndexChanged += new System.EventHandler(this.sessionDisplay_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Session";
            // 
            // addNewSession
            // 
            this.addNewSession.Location = new System.Drawing.Point(261, 228);
            this.addNewSession.Name = "addNewSession";
            this.addNewSession.Size = new System.Drawing.Size(120, 23);
            this.addNewSession.TabIndex = 24;
            this.addNewSession.Text = "Add New Session";
            this.addNewSession.UseVisualStyleBackColor = true;
            this.addNewSession.Click += new System.EventHandler(this.addNewSession_Click);
            // 
            // removeSession
            // 
            this.removeSession.Location = new System.Drawing.Point(261, 258);
            this.removeSession.Name = "removeSession";
            this.removeSession.Size = new System.Drawing.Size(120, 23);
            this.removeSession.TabIndex = 25;
            this.removeSession.Text = "Remove Session";
            this.removeSession.UseVisualStyleBackColor = true;
            this.removeSession.Click += new System.EventHandler(this.removeSession_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1414, 703);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 728);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "MainInterface";
            this.Text = "AscensionControl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainInterface_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadTracker;
        private System.Windows.Forms.Button unloadTracker;
        private System.Windows.Forms.ListBox studyDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox subjectDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox trialDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addNewStudy;
        private System.Windows.Forms.Button removeStudy;
        private System.Windows.Forms.Button addNewSubject;
        private System.Windows.Forms.Button removeSubject;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button nextTrial;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button removeTrial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox sessionDisplay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addNewSession;
        private System.Windows.Forms.Button removeSession;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button addTrial;
        private System.Windows.Forms.RichTextBox sensorInfo;
        private System.Windows.Forms.Button getSensors;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ExportStudyButton;
    }
}

