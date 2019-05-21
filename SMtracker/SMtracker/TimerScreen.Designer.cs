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
            this.TimerLabel = new System.Windows.Forms.Label();
            this.TimeActive = new System.Windows.Forms.Label();
            this.DataBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ExerciseBtn = new System.Windows.Forms.Button();
            this.CheckActive = new System.Windows.Forms.Timer(this.components);
            this.ExerciseTime = new System.Windows.Forms.Label();
            this.ExerciseCounter = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.VGUpdate = new System.Windows.Forms.Timer(this.components);
            this.mpLbl = new System.Windows.Forms.Label();
            this.MaxPlaylbl = new System.Windows.Forms.Label();
            this.TimeLeftLbl = new System.Windows.Forms.Label();
            this.TLlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ExerciseCounter)).BeginInit();
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
            this.DataBtn.Location = new System.Drawing.Point(18, 116);
            this.DataBtn.Name = "DataBtn";
            this.DataBtn.Size = new System.Drawing.Size(75, 23);
            this.DataBtn.TabIndex = 2;
            this.DataBtn.Text = "View Data";
            this.DataBtn.UseVisualStyleBackColor = true;
            this.DataBtn.Click += new System.EventHandler(this.ViewData);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(210, 116);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 4;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ExerciseBtn
            // 
            this.ExerciseBtn.Location = new System.Drawing.Point(210, 62);
            this.ExerciseBtn.Name = "ExerciseBtn";
            this.ExerciseBtn.Size = new System.Drawing.Size(75, 23);
            this.ExerciseBtn.TabIndex = 3;
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
            // ExerciseCounter
            // 
            this.ExerciseCounter.Location = new System.Drawing.Point(90, 65);
            this.ExerciseCounter.Maximum = new decimal(new int[] {
            960,
            0,
            0,
            0});
            this.ExerciseCounter.Name = "ExerciseCounter";
            this.ExerciseCounter.Size = new System.Drawing.Size(60, 20);
            this.ExerciseCounter.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "minutes";
            // 
            // VGUpdate
            // 
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
            this.TimeLeftLbl.Location = new System.Drawing.Point(236, 13);
            this.TimeLeftLbl.Name = "TimeLeftLbl";
            this.TimeLeftLbl.Size = new System.Drawing.Size(49, 13);
            this.TimeLeftLbl.TabIndex = 10;
            this.TimeLeftLbl.Text = "00:00:00";
            // 
            // TLlbl
            // 
            this.TLlbl.AutoSize = true;
            this.TLlbl.Location = new System.Drawing.Point(169, 13);
            this.TLlbl.Name = "TLlbl";
            this.TLlbl.Size = new System.Drawing.Size(50, 13);
            this.TLlbl.TabIndex = 11;
            this.TLlbl.Text = "Time left:";
            // 
            // TimerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 148);
            this.Controls.Add(this.TLlbl);
            this.Controls.Add(this.TimeLeftLbl);
            this.Controls.Add(this.MaxPlaylbl);
            this.Controls.Add(this.mpLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExerciseCounter);
            this.Controls.Add(this.ExerciseTime);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ExerciseBtn);
            this.Controls.Add(this.DataBtn);
            this.Controls.Add(this.TimeActive);
            this.Controls.Add(this.TimerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TimerScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Self-Management Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Save);
            ((System.ComponentModel.ISupportInitialize)(this.ExerciseCounter)).EndInit();
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
        private System.Windows.Forms.NumericUpDown ExerciseCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer VGUpdate;
        private System.Windows.Forms.Label mpLbl;
        private System.Windows.Forms.Label MaxPlaylbl;
        private System.Windows.Forms.Label TimeLeftLbl;
        private System.Windows.Forms.Label TLlbl;
    }
}

