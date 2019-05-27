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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ExMins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExHours)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Location = new System.Drawing.Point(15, 38);
            this.TimerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(89, 17);
            this.TimerLabel.TabIndex = 0;
            this.TimerLabel.Text = "Time played:";
            // 
            // TimeActive
            // 
            this.TimeActive.AutoSize = true;
            this.TimeActive.Location = new System.Drawing.Point(113, 38);
            this.TimeActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeActive.Name = "TimeActive";
            this.TimeActive.Size = new System.Drawing.Size(64, 17);
            this.TimeActive.TabIndex = 1;
            this.TimeActive.Text = "00:00:00";
            // 
            // ExerciseBtn
            // 
            this.ExerciseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExerciseBtn.Location = new System.Drawing.Point(347, 98);
            this.ExerciseBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExerciseBtn.Name = "ExerciseBtn";
            this.ExerciseBtn.Size = new System.Drawing.Size(100, 28);
            this.ExerciseBtn.TabIndex = 6;
            this.ExerciseBtn.Text = "Add";
            this.ExerciseBtn.UseVisualStyleBackColor = true;
            this.ExerciseBtn.Click += new System.EventHandler(this.AddExercise);
            // 
            // CheckActive
            // 
            this.CheckActive.Interval = 10000;
            this.CheckActive.Tick += new System.EventHandler(this.CheckRunning);
            // 
            // ExerciseTime
            // 
            this.ExerciseTime.AutoSize = true;
            this.ExerciseTime.Location = new System.Drawing.Point(17, 105);
            this.ExerciseTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExerciseTime.Name = "ExerciseTime";
            this.ExerciseTime.Size = new System.Drawing.Size(95, 17);
            this.ExerciseTime.TabIndex = 5;
            this.ExerciseTime.Text = "Exercise time:";
            // 
            // ExMins
            // 
            this.ExMins.Location = new System.Drawing.Point(227, 102);
            this.ExMins.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExMins.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.ExMins.Name = "ExMins";
            this.ExMins.Size = new System.Drawing.Size(49, 22);
            this.ExMins.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
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
            this.mpLbl.Location = new System.Drawing.Point(15, 71);
            this.mpLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mpLbl.Name = "mpLbl";
            this.mpLbl.Size = new System.Drawing.Size(67, 17);
            this.mpLbl.TabIndex = 8;
            this.mpLbl.Text = "Max play:";
            // 
            // MaxPlaylbl
            // 
            this.MaxPlaylbl.AutoSize = true;
            this.MaxPlaylbl.Location = new System.Drawing.Point(113, 71);
            this.MaxPlaylbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxPlaylbl.Name = "MaxPlaylbl";
            this.MaxPlaylbl.Size = new System.Drawing.Size(64, 17);
            this.MaxPlaylbl.TabIndex = 9;
            this.MaxPlaylbl.Text = "00:00:00";
            // 
            // TimeLeftLbl
            // 
            this.TimeLeftLbl.AutoSize = true;
            this.TimeLeftLbl.Location = new System.Drawing.Point(284, 38);
            this.TimeLeftLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeLeftLbl.Name = "TimeLeftLbl";
            this.TimeLeftLbl.Size = new System.Drawing.Size(64, 17);
            this.TimeLeftLbl.TabIndex = 10;
            this.TimeLeftLbl.Text = "00:00:00";
            // 
            // TLlbl
            // 
            this.TLlbl.AutoSize = true;
            this.TLlbl.Location = new System.Drawing.Point(209, 38);
            this.TLlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TLlbl.Name = "TLlbl";
            this.TLlbl.Size = new System.Drawing.Size(66, 17);
            this.TLlbl.TabIndex = 11;
            this.TLlbl.Text = "Time left:";
            // 
            // ExHours
            // 
            this.ExHours.Location = new System.Drawing.Point(117, 102);
            this.ExHours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExHours.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ExHours.Name = "ExHours";
            this.ExHours.Size = new System.Drawing.Size(49, 22);
            this.ExHours.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "hours";
            // 
            // walkRBtn
            // 
            this.walkRBtn.AutoSize = true;
            this.walkRBtn.Checked = true;
            this.walkRBtn.Location = new System.Drawing.Point(63, 134);
            this.walkRBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.walkRBtn.Name = "walkRBtn";
            this.walkRBtn.Size = new System.Drawing.Size(60, 21);
            this.walkRBtn.TabIndex = 2;
            this.walkRBtn.TabStop = true;
            this.walkRBtn.Text = "Walk";
            this.walkRBtn.UseVisualStyleBackColor = true;
            // 
            // yardworkRbtn
            // 
            this.yardworkRbtn.AutoSize = true;
            this.yardworkRbtn.Location = new System.Drawing.Point(139, 134);
            this.yardworkRbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yardworkRbtn.Name = "yardworkRbtn";
            this.yardworkRbtn.Size = new System.Drawing.Size(88, 21);
            this.yardworkRbtn.TabIndex = 3;
            this.yardworkRbtn.Text = "Yardwork";
            this.yardworkRbtn.UseVisualStyleBackColor = true;
            // 
            // bikeRBtn
            // 
            this.bikeRBtn.AutoSize = true;
            this.bikeRBtn.Location = new System.Drawing.Point(240, 134);
            this.bikeRBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bikeRBtn.Name = "bikeRBtn";
            this.bikeRBtn.Size = new System.Drawing.Size(56, 21);
            this.bikeRBtn.TabIndex = 4;
            this.bikeRBtn.Text = "Bike";
            this.bikeRBtn.UseVisualStyleBackColor = true;
            // 
            // workoutRBtn
            // 
            this.workoutRBtn.AutoSize = true;
            this.workoutRBtn.Location = new System.Drawing.Point(311, 134);
            this.workoutRBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.workoutRBtn.Name = "workoutRBtn";
            this.workoutRBtn.Size = new System.Drawing.Size(82, 21);
            this.workoutRBtn.TabIndex = 5;
            this.workoutRBtn.Text = "Workout";
            this.workoutRBtn.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(465, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDataToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewDataToolStripMenuItem
            // 
            this.viewDataToolStripMenuItem.Name = "viewDataToolStripMenuItem";
            this.viewDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.viewDataToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.viewDataToolStripMenuItem.Text = "View Data";
            this.viewDataToolStripMenuItem.Click += new System.EventHandler(this.ViewData);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.ShowOptions);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.ShowShortcutKeys = false;
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // TimerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 170);
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
            this.Controls.Add(this.ExerciseBtn);
            this.Controls.Add(this.TimeActive);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "TimerScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Self-Management Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Save);
            ((System.ComponentModel.ISupportInitialize)(this.ExMins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExHours)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label TimeActive;
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

