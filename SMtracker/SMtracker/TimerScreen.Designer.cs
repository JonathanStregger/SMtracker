namespace SMtracker
{
    partial class TimerScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerScreen));
            this.TimerLabel = new System.Windows.Forms.Label();
            this.TimeActive = new System.Windows.Forms.Label();
            this.DataBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ExerciseBtn = new System.Windows.Forms.Button();
            this.CheckActive = new System.Windows.Forms.Timer(this.components);
            this.ExerciseTime = new System.Windows.Forms.Label();
            this.ExMins = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.VGUpdate = new System.Windows.Forms.Timer(this.components);
            this.mpLbl = new System.Windows.Forms.Label();
            this.MaxPlaylbl = new System.Windows.Forms.Label();
            this.TimeLeftLbl = new System.Windows.Forms.Label();
            this.TLlbl = new System.Windows.Forms.Label();
            this.ExHours = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.walkRBtn = new System.Windows.Forms.RadioButton();
            this.yardworkRbtn = new System.Windows.Forms.RadioButton();
            this.bikeRBtn = new System.Windows.Forms.RadioButton();
            this.workoutRBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ExMins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExHours)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Location = new System.Drawing.Point(13, 13);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(67, 13);
            this.TimerLabel.TabIndex = 0;
            this.TimerLabel.Text = "Time played:";
            // 
            // TimeActive
            // 
            this.TimeActive.AutoSize = true;
            this.TimeActive.Location = new System.Drawing.Point(87, 13);
            this.TimeActive.Name = "TimeActive";
            this.TimeActive.Size = new System.Drawing.Size(49, 13);
            this.TimeActive.TabIndex = 1;
            this.TimeActive.Text = "00:00:00";
            // 
            // DataBtn
            // 
            this.DataBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataBtn.Location = new System.Drawing.Point(12, 121);
            this.DataBtn.Name = "DataBtn";
            this.DataBtn.Size = new System.Drawing.Size(75, 23);
            this.DataBtn.TabIndex = 7;
            this.DataBtn.Text = "View Data";
            this.DataBtn.UseVisualStyleBackColor = true;
            this.DataBtn.Click += new System.EventHandler(this.ViewData);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitBtn.Location = new System.Drawing.Point(262, 121);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ExerciseBtn
            // 
            this.ExerciseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExerciseBtn.Location = new System.Drawing.Point(262, 62);
            this.ExerciseBtn.Name = "ExerciseBtn";
            this.ExerciseBtn.Size = new System.Drawing.Size(75, 23);
            this.ExerciseBtn.TabIndex = 6;
            this.ExerciseBtn.Text = "Add";
            this.ExerciseBtn.UseVisualStyleBackColor = true;
            this.ExerciseBtn.Click += new System.EventHandler(this.ExerciseBtn_Click);
            // 
            // CheckActive
            // 
            this.CheckActive.Interval = 30000;
            this.CheckActive.Tick += new System.EventHandler(this.CheckRunning);
            // 
            // ExerciseTime
            // 
            this.ExerciseTime.AutoSize = true;
            this.ExerciseTime.Location = new System.Drawing.Point(15, 67);
            this.ExerciseTime.Name = "ExerciseTime";
            this.ExerciseTime.Size = new System.Drawing.Size(72, 13);
            this.ExerciseTime.TabIndex = 5;
            this.ExerciseTime.Text = "Exercise time:";
            // 
            // ExMins
            // 
            this.ExMins.Location = new System.Drawing.Point(172, 65);
            this.ExMins.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.ExMins.Name = "ExMins";
            this.ExMins.Size = new System.Drawing.Size(37, 20);
            this.ExMins.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "minutes";
            // 
            // VGUpdate
            // 
            this.VGUpdate.Interval = 1000;
            this.VGUpdate.Tick += new System.EventHandler(this.UpdateTime);
            // 
            // mpLbl
            // 
            this.mpLbl.AutoSize = true;
            this.mpLbl.Location = new System.Drawing.Point(13, 40);
            this.mpLbl.Name = "mpLbl";
            this.mpLbl.Size = new System.Drawing.Size(52, 13);
            this.mpLbl.TabIndex = 8;
            this.mpLbl.Text = "Max play:";
            // 
            // MaxPlaylbl
            // 
            this.MaxPlaylbl.AutoSize = true;
            this.MaxPlaylbl.Location = new System.Drawing.Point(87, 40);
            this.MaxPlaylbl.Name = "MaxPlaylbl";
            this.MaxPlaylbl.Size = new System.Drawing.Size(49, 13);
            this.MaxPlaylbl.TabIndex = 9;
            this.MaxPlaylbl.Text = "00:00:00";
            // 
            // TimeLeftLbl
            // 
            this.TimeLeftLbl.AutoSize = true;
            this.TimeLeftLbl.Location = new System.Drawing.Point(215, 13);
            this.TimeLeftLbl.Name = "TimeLeftLbl";
            this.TimeLeftLbl.Size = new System.Drawing.Size(49, 13);
            this.TimeLeftLbl.TabIndex = 10;
            this.TimeLeftLbl.Text = "00:00:00";
            // 
            // TLlbl
            // 
            this.TLlbl.AutoSize = true;
            this.TLlbl.Location = new System.Drawing.Point(159, 13);
            this.TLlbl.Name = "TLlbl";
            this.TLlbl.Size = new System.Drawing.Size(50, 13);
            this.TLlbl.TabIndex = 11;
            this.TLlbl.Text = "Time left:";
            // 
            // ExHours
            // 
            this.ExHours.Location = new System.Drawing.Point(90, 65);
            this.ExHours.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ExHours.Name = "ExHours";
            this.ExHours.Size = new System.Drawing.Size(37, 20);
            this.ExHours.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "hours";
            // 
            // walkRBtn
            // 
            this.walkRBtn.AutoSize = true;
            this.walkRBtn.Checked = true;
            this.walkRBtn.Location = new System.Drawing.Point(49, 91);
            this.walkRBtn.Name = "walkRBtn";
            this.walkRBtn.Size = new System.Drawing.Size(50, 17);
            this.walkRBtn.TabIndex = 2;
            this.walkRBtn.TabStop = true;
            this.walkRBtn.Text = "Walk";
            this.walkRBtn.UseVisualStyleBackColor = true;
            // 
            // yardworkRbtn
            // 
            this.yardworkRbtn.AutoSize = true;
            this.yardworkRbtn.Location = new System.Drawing.Point(106, 91);
            this.yardworkRbtn.Name = "yardworkRbtn";
            this.yardworkRbtn.Size = new System.Drawing.Size(70, 17);
            this.yardworkRbtn.TabIndex = 3;
            this.yardworkRbtn.Text = "Yardwork";
            this.yardworkRbtn.UseVisualStyleBackColor = true;
            // 
            // bikeRBtn
            // 
            this.bikeRBtn.AutoSize = true;
            this.bikeRBtn.Location = new System.Drawing.Point(182, 91);
            this.bikeRBtn.Name = "bikeRBtn";
            this.bikeRBtn.Size = new System.Drawing.Size(46, 17);
            this.bikeRBtn.TabIndex = 4;
            this.bikeRBtn.Text = "Bike";
            this.bikeRBtn.UseVisualStyleBackColor = true;
            // 
            // workoutRBtn
            // 
            this.workoutRBtn.AutoSize = true;
            this.workoutRBtn.Location = new System.Drawing.Point(235, 91);
            this.workoutRBtn.Name = "workoutRBtn";
            this.workoutRBtn.Size = new System.Drawing.Size(66, 17);
            this.workoutRBtn.TabIndex = 5;
            this.workoutRBtn.Text = "Workout";
            this.workoutRBtn.UseVisualStyleBackColor = true;
            // 
            // TimerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 156);
            this.Controls.Add(this.workoutRBtn);
            this.Controls.Add(this.bikeRBtn);
            this.Controls.Add(this.yardworkRbtn);
            this.Controls.Add(this.walkRBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExHours);
            this.Controls.Add(this.TLlbl);
            this.Controls.Add(this.TimeLeftLbl);
            this.Controls.Add(this.MaxPlaylbl);
            this.Controls.Add(this.mpLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExMins);
            this.Controls.Add(this.ExerciseTime);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ExerciseBtn);
            this.Controls.Add(this.DataBtn);
            this.Controls.Add(this.TimeActive);
            this.Controls.Add(this.TimerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TimerScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Self-Management Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Save);
            ((System.ComponentModel.ISupportInitialize)(this.ExMins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label TimeActive;
        private System.Windows.Forms.Button DataBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button ExerciseBtn;
        private System.Windows.Forms.Timer CheckActive;
        private System.Windows.Forms.Label ExerciseTime;
        private System.Windows.Forms.NumericUpDown ExMins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer VGUpdate;
        private System.Windows.Forms.Label mpLbl;
        private System.Windows.Forms.Label MaxPlaylbl;
        private System.Windows.Forms.Label TimeLeftLbl;
        private System.Windows.Forms.Label TLlbl;
        private System.Windows.Forms.NumericUpDown ExHours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton walkRBtn;
        private System.Windows.Forms.RadioButton yardworkRbtn;
        private System.Windows.Forms.RadioButton bikeRBtn;
        private System.Windows.Forms.RadioButton workoutRBtn;
    }
}

