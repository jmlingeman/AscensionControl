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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.qualityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nextTrial = new System.Windows.Forms.Button();
            this.removeTrial = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabcontrol = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.exportSubjectButton = new System.Windows.Forms.Button();
            this.exportSubjectByTrialButton = new System.Windows.Forms.Button();
            this.exportStudyOneFileButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.radiusSettings = new System.Windows.Forms.ComboBox();
            this.samplingFreq = new System.Windows.Forms.TextBox();
            this.syncstatus = new System.Windows.Forms.Button();
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
            this.updateOldTimestampsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qualityChart)).BeginInit();
            this.tabcontrol.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadTracker
            // 
            this.loadTracker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadTracker.Location = new System.Drawing.Point(565, 372);
            this.loadTracker.Name = "loadTracker";
            this.loadTracker.Size = new System.Drawing.Size(168, 53);
            this.loadTracker.TabIndex = 0;
            this.loadTracker.Text = "Load Tracker";
            this.loadTracker.UseVisualStyleBackColor = true;
            this.loadTracker.Click += new System.EventHandler(this.loadTracker_Click);
            // 
            // unloadTracker
            // 
            this.unloadTracker.Enabled = false;
            this.unloadTracker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unloadTracker.Location = new System.Drawing.Point(565, 629);
            this.unloadTracker.Name = "unloadTracker";
            this.unloadTracker.Size = new System.Drawing.Size(168, 54);
            this.unloadTracker.TabIndex = 1;
            this.unloadTracker.Text = "Unload Tracker";
            this.unloadTracker.UseVisualStyleBackColor = true;
            this.unloadTracker.Click += new System.EventHandler(this.unloadTracker_Click);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
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
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(387, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
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
            // qualityChart
            // 
            this.qualityChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.AxisY.Maximum = 15000D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.qualityChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.qualityChart.Legends.Add(legend1);
            this.qualityChart.Location = new System.Drawing.Point(739, 49);
            this.qualityChart.Name = "qualityChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.qualityChart.Series.Add(series1);
            this.qualityChart.Size = new System.Drawing.Size(443, 321);
            this.qualityChart.TabIndex = 13;
            this.qualityChart.Text = "chart2";
            // 
            // nextTrial
            // 
            this.nextTrial.BackColor = System.Drawing.Color.DarkGray;
            this.nextTrial.Enabled = false;
            this.nextTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextTrial.Location = new System.Drawing.Point(565, 563);
            this.nextTrial.Name = "nextTrial";
            this.nextTrial.Size = new System.Drawing.Size(168, 60);
            this.nextTrial.TabIndex = 14;
            this.nextTrial.Text = "Next Trial";
            this.nextTrial.UseVisualStyleBackColor = false;
            this.nextTrial.Click += new System.EventHandler(this.nextTrial_Click);
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
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(877, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
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
            // tabcontrol
            // 
            this.tabcontrol.Controls.Add(this.tabPage1);
            this.tabcontrol.Controls.Add(this.tabPage2);
            this.tabcontrol.Location = new System.Drawing.Point(2, 1);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(1169, 729);
            this.tabcontrol.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.exportSubjectButton);
            this.tabPage1.Controls.Add(this.exportSubjectByTrialButton);
            this.tabPage1.Controls.Add(this.exportStudyOneFileButton);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.radiusSettings);
            this.tabPage1.Controls.Add(this.samplingFreq);
            this.tabPage1.Controls.Add(this.syncstatus);
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
            this.tabPage1.Controls.Add(this.qualityChart);
            this.tabPage1.Controls.Add(this.nextTrial);
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
            this.tabPage1.Size = new System.Drawing.Size(1161, 703);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Controller";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // exportSubjectButton
            // 
            this.exportSubjectButton.Location = new System.Drawing.Point(565, 101);
            this.exportSubjectButton.Name = "exportSubjectButton";
            this.exportSubjectButton.Size = new System.Drawing.Size(168, 47);
            this.exportSubjectButton.TabIndex = 49;
            this.exportSubjectButton.Text = "Export Subject";
            this.exportSubjectButton.UseVisualStyleBackColor = true;
            this.exportSubjectButton.Click += new System.EventHandler(this.exportSubjectButton_Click);
            // 
            // exportSubjectByTrialButton
            // 
            this.exportSubjectByTrialButton.Location = new System.Drawing.Point(565, 228);
            this.exportSubjectByTrialButton.Name = "exportSubjectByTrialButton";
            this.exportSubjectByTrialButton.Size = new System.Drawing.Size(168, 47);
            this.exportSubjectByTrialButton.TabIndex = 48;
            this.exportSubjectByTrialButton.Text = "Export Subject by Trial";
            this.exportSubjectByTrialButton.UseVisualStyleBackColor = true;
            this.exportSubjectByTrialButton.Click += new System.EventHandler(this.exportSubjectByTrialButton_Click);
            // 
            // exportStudyOneFileButton
            // 
            this.exportStudyOneFileButton.Location = new System.Drawing.Point(565, 48);
            this.exportStudyOneFileButton.Name = "exportStudyOneFileButton";
            this.exportStudyOneFileButton.Size = new System.Drawing.Size(168, 47);
            this.exportStudyOneFileButton.TabIndex = 47;
            this.exportStudyOneFileButton.Text = "Export Study";
            this.exportStudyOneFileButton.UseVisualStyleBackColor = true;
            this.exportStudyOneFileButton.Click += new System.EventHandler(this.exportStudyOneFileButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(763, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(331, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "NOTE: These settings may only be set when the tracker is unloaded.";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(760, 454);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(316, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Tracker Radius in inches.  144 setting is only for large transmittor. ";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(763, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(288, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Update Frequency (Hz).  Range: 60.0 - 720.0.  Default 240.";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // radiusSettings
            // 
            this.radiusSettings.DisplayMember = "36";
            this.radiusSettings.FormattingEnabled = true;
            this.radiusSettings.Items.AddRange(new object[] {
            "36",
            "72",
            "144"});
            this.radiusSettings.Location = new System.Drawing.Point(763, 470);
            this.radiusSettings.Name = "radiusSettings";
            this.radiusSettings.Size = new System.Drawing.Size(121, 21);
            this.radiusSettings.TabIndex = 43;
            this.radiusSettings.SelectedIndexChanged += new System.EventHandler(this.radiusSettings_SelectedIndexChanged);
            // 
            // samplingFreq
            // 
            this.samplingFreq.Location = new System.Drawing.Point(763, 422);
            this.samplingFreq.Name = "samplingFreq";
            this.samplingFreq.Size = new System.Drawing.Size(121, 20);
            this.samplingFreq.TabIndex = 42;
            this.samplingFreq.Text = "240";
            this.samplingFreq.TextChanged += new System.EventHandler(this.samplingFreq_TextChanged);
            // 
            // syncstatus
            // 
            this.syncstatus.BackColor = System.Drawing.Color.Red;
            this.syncstatus.Enabled = false;
            this.syncstatus.Location = new System.Drawing.Point(565, 288);
            this.syncstatus.Name = "syncstatus";
            this.syncstatus.Size = new System.Drawing.Size(168, 54);
            this.syncstatus.TabIndex = 41;
            this.syncstatus.Text = "Sync Status";
            this.syncstatus.UseVisualStyleBackColor = false;
            // 
            // ExportStudyButton
            // 
            this.ExportStudyButton.Location = new System.Drawing.Point(565, 175);
            this.ExportStudyButton.Name = "ExportStudyButton";
            this.ExportStudyButton.Size = new System.Drawing.Size(168, 47);
            this.ExportStudyButton.TabIndex = 31;
            this.ExportStudyButton.Text = "Export Study by Trial";
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
            this.startButton.BackColor = System.Drawing.Color.DarkGray;
            this.startButton.Enabled = false;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(565, 431);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(168, 60);
            this.startButton.TabIndex = 27;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.DarkGray;
            this.stopButton.Enabled = false;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Location = new System.Drawing.Point(565, 497);
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
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(261, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
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
            this.tabPage2.Controls.Add(this.updateOldTimestampsButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1161, 703);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // updateOldTimestampsButton
            // 
            this.updateOldTimestampsButton.Location = new System.Drawing.Point(39, 156);
            this.updateOldTimestampsButton.Name = "updateOldTimestampsButton";
            this.updateOldTimestampsButton.Size = new System.Drawing.Size(134, 23);
            this.updateOldTimestampsButton.TabIndex = 7;
            this.updateOldTimestampsButton.Text = "Update Old Timestamps";
            this.updateOldTimestampsButton.UseVisualStyleBackColor = true;
            this.updateOldTimestampsButton.Click += new System.EventHandler(this.updateOldTimestampsButton_Click);
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 728);
            this.Controls.Add(this.tabcontrol);
            this.KeyPreview = true;
            this.Name = "MainInterface";
            this.Text = "AscensionControl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainInterface_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            ((System.ComponentModel.ISupportInitialize)(this.qualityChart)).EndInit();
            this.tabcontrol.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.Button nextTrial;
        private System.Windows.Forms.Button removeTrial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabcontrol;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox sessionDisplay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addNewSession;
        private System.Windows.Forms.Button removeSession;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button addTrial;
        private System.Windows.Forms.Button getSensors;
        private System.Windows.Forms.Button ExportStudyButton;
        public System.Windows.Forms.RichTextBox sensorInfo;
        public System.Windows.Forms.DataVisualization.Charting.Chart qualityChart;
        private System.Windows.Forms.Button updateOldTimestampsButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox radiusSettings;
        private System.Windows.Forms.TextBox samplingFreq;
        public System.Windows.Forms.Button syncstatus;
        private System.Windows.Forms.Button exportStudyOneFileButton;
        private System.Windows.Forms.Button exportSubjectButton;
        private System.Windows.Forms.Button exportSubjectByTrialButton;
    }
}

