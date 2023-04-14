namespace WindowsFormsApp
{
    partial class RangListsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangListsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.Profile = new System.Windows.Forms.DataGridViewImageColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Goals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YellowCards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attendance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreatePdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlayers
            // 
            resources.ApplyResources(this.dgvPlayers, "dgvPlayers");
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AllowUserToResizeRows = false;
            this.dgvPlayers.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Profile,
            this.PlayerName,
            this.Goals,
            this.YellowCards});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlayers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPlayers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPlayers.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvPlayers.RowTemplate.Height = 50;
            this.dgvPlayers.RowTemplate.ReadOnly = true;
            // 
            // Profile
            // 
            resources.ApplyResources(this.Profile, "Profile");
            this.Profile.Name = "Profile";
            this.Profile.ReadOnly = true;
            // 
            // PlayerName
            // 
            resources.ApplyResources(this.PlayerName, "PlayerName");
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // Goals
            // 
            resources.ApplyResources(this.Goals, "Goals");
            this.Goals.Name = "Goals";
            this.Goals.ReadOnly = true;
            // 
            // YellowCards
            // 
            resources.ApplyResources(this.YellowCards, "YellowCards");
            this.YellowCards.Name = "YellowCards";
            this.YellowCards.ReadOnly = true;
            // 
            // dgvMatches
            // 
            resources.ApplyResources(this.dgvMatches, "dgvMatches");
            this.dgvMatches.AllowUserToAddRows = false;
            this.dgvMatches.AllowUserToDeleteRows = false;
            this.dgvMatches.AllowUserToResizeRows = false;
            this.dgvMatches.BackgroundColor = System.Drawing.Color.White;
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Location,
            this.Attendance,
            this.HomeCountry,
            this.AwayCountry});
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.RowTemplate.Height = 29;
            this.dgvMatches.RowTemplate.ReadOnly = true;
            // 
            // Location
            // 
            resources.ApplyResources(this.Location, "Location");
            this.Location.Name = "Location";
            // 
            // Attendance
            // 
            resources.ApplyResources(this.Attendance, "Attendance");
            this.Attendance.Name = "Attendance";
            // 
            // HomeCountry
            // 
            resources.ApplyResources(this.HomeCountry, "HomeCountry");
            this.HomeCountry.Name = "HomeCountry";
            // 
            // AwayCountry
            // 
            resources.ApplyResources(this.AwayCountry, "AwayCountry");
            this.AwayCountry.Name = "AwayCountry";
            // 
            // btnCreatePdf
            // 
            resources.ApplyResources(this.btnCreatePdf, "btnCreatePdf");
            this.btnCreatePdf.BackColor = System.Drawing.SystemColors.Control;
            this.btnCreatePdf.FlatAppearance.BorderSize = 0;
            this.btnCreatePdf.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreatePdf.Name = "btnCreatePdf";
            this.btnCreatePdf.UseVisualStyleBackColor = false;
            this.btnCreatePdf.Click += new System.EventHandler(this.btnCreatePdf_Click);
            // 
            // RangListsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnCreatePdf);
            this.Controls.Add(this.dgvMatches);
            this.Controls.Add(this.dgvPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RangListsForm";
            this.Load += new System.EventHandler(this.RangListsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvPlayers;
        private DataGridView dgvMatches;
        private Button btnCreatePdf;
        private DataGridViewImageColumn Profile;
        private DataGridViewTextBoxColumn PlayerName;
        private DataGridViewTextBoxColumn Goals;
        private DataGridViewTextBoxColumn YellowCards;
        private DataGridViewTextBoxColumn Location;
        private DataGridViewTextBoxColumn Attendance;
        private DataGridViewTextBoxColumn HomeCountry;
        private DataGridViewTextBoxColumn AwayCountry;
    }
}