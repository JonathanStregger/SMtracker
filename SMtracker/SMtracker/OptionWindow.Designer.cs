namespace SMtracker
{
    partial class OptionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionWindow));
            this.VG2TrackLbl = new System.Windows.Forms.Label();
            this.VG2Track = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.VGName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Processes = new System.Windows.Forms.DataGridView();
            this.TrackButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.DeleteTracked = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VG2Track)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Processes)).BeginInit();
            this.SuspendLayout();
            // 
            // VG2TrackLbl
            // 
            this.VG2TrackLbl.AutoSize = true;
            this.VG2TrackLbl.Location = new System.Drawing.Point(17, 16);
            this.VG2TrackLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VG2TrackLbl.Name = "VG2TrackLbl";
            this.VG2TrackLbl.Size = new System.Drawing.Size(144, 17);
            this.VG2TrackLbl.TabIndex = 0;
            this.VG2TrackLbl.Text = "Video Games to track";
            // 
            // VG2Track
            // 
            this.VG2Track.AllowUserToAddRows = false;
            this.VG2Track.AllowUserToDeleteRows = false;
            this.VG2Track.AllowUserToOrderColumns = true;
            this.VG2Track.AllowUserToResizeColumns = false;
            this.VG2Track.AllowUserToResizeRows = false;
            this.VG2Track.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VG2Track.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.VG2Track.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VG2Track.Location = new System.Drawing.Point(17, 37);
            this.VG2Track.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VG2Track.MultiSelect = false;
            this.VG2Track.Name = "VG2Track";
            this.VG2Track.RowHeadersVisible = false;
            this.VG2Track.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.VG2Track.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VG2Track.Size = new System.Drawing.Size(363, 465);
            this.VG2Track.TabIndex = 4;
            this.VG2Track.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EditTracked);
            this.VG2Track.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.SubmitEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add new process";
            // 
            // VGName
            // 
            this.VGName.Location = new System.Drawing.Point(521, 48);
            this.VGName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VGName.Name = "VGName";
            this.VGName.Size = new System.Drawing.Size(299, 22);
            this.VGName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "VG Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select a process to track:";
            // 
            // Processes
            // 
            this.Processes.AllowUserToAddRows = false;
            this.Processes.AllowUserToDeleteRows = false;
            this.Processes.AllowUserToResizeColumns = false;
            this.Processes.AllowUserToResizeRows = false;
            this.Processes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Processes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Processes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Processes.Location = new System.Drawing.Point(447, 134);
            this.Processes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Processes.MultiSelect = false;
            this.Processes.Name = "Processes";
            this.Processes.ReadOnly = true;
            this.Processes.RowHeadersVisible = false;
            this.Processes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Processes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Processes.Size = new System.Drawing.Size(376, 368);
            this.Processes.TabIndex = 2;
            // 
            // TrackButton
            // 
            this.TrackButton.Location = new System.Drawing.Point(721, 510);
            this.TrackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TrackButton.Name = "TrackButton";
            this.TrackButton.Size = new System.Drawing.Size(100, 28);
            this.TrackButton.TabIndex = 3;
            this.TrackButton.Text = "Track";
            this.TrackButton.UseVisualStyleBackColor = true;
            this.TrackButton.Click += new System.EventHandler(this.TrackNewVG);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Search:";
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(515, 102);
            this.SearchBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(307, 22);
            this.SearchBar.TabIndex = 1;
            this.SearchBar.TextChanged += new System.EventHandler(this.Serach);
            // 
            // DeleteTracked
            // 
            this.DeleteTracked.Location = new System.Drawing.Point(280, 510);
            this.DeleteTracked.Name = "DeleteTracked";
            this.DeleteTracked.Size = new System.Drawing.Size(100, 28);
            this.DeleteTracked.TabIndex = 9;
            this.DeleteTracked.Text = "Delete";
            this.DeleteTracked.UseVisualStyleBackColor = true;
            this.DeleteTracked.Click += new System.EventHandler(this.DeleteTracker);
            // 
            // OptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 554);
            this.Controls.Add(this.DeleteTracked);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TrackButton);
            this.Controls.Add(this.Processes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VGName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VG2Track);
            this.Controls.Add(this.VG2TrackLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "OptionWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.LoadVGs);
            ((System.ComponentModel.ISupportInitialize)(this.VG2Track)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Processes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VG2TrackLbl;
        private System.Windows.Forms.DataGridView VG2Track;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox VGName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Processes;
        private System.Windows.Forms.Button TrackButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Button DeleteTracked;
    }
}