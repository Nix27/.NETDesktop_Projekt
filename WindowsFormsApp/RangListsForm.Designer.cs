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
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.btnGoals = new System.Windows.Forms.Button();
            this.btnYellowCards = new System.Windows.Forms.Button();
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.btnCreatePdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Location = new System.Drawing.Point(39, 103);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.RowHeadersWidth = 51;
            this.dgvPlayers.RowTemplate.Height = 29;
            this.dgvPlayers.Size = new System.Drawing.Size(450, 386);
            this.dgvPlayers.TabIndex = 0;
            // 
            // btnGoals
            // 
            this.btnGoals.Location = new System.Drawing.Point(39, 45);
            this.btnGoals.Name = "btnGoals";
            this.btnGoals.Size = new System.Drawing.Size(148, 36);
            this.btnGoals.TabIndex = 1;
            this.btnGoals.Text = "Goals";
            this.btnGoals.UseVisualStyleBackColor = true;
            this.btnGoals.Click += new System.EventHandler(this.btnGoals_Click);
            // 
            // btnYellowCards
            // 
            this.btnYellowCards.Location = new System.Drawing.Point(193, 45);
            this.btnYellowCards.Name = "btnYellowCards";
            this.btnYellowCards.Size = new System.Drawing.Size(148, 36);
            this.btnYellowCards.TabIndex = 2;
            this.btnYellowCards.Text = "Yellow cards";
            this.btnYellowCards.UseVisualStyleBackColor = true;
            this.btnYellowCards.Click += new System.EventHandler(this.btnYellowCards_Click);
            // 
            // dgvMatches
            // 
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatches.Location = new System.Drawing.Point(554, 103);
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.RowHeadersWidth = 51;
            this.dgvMatches.RowTemplate.Height = 29;
            this.dgvMatches.Size = new System.Drawing.Size(549, 386);
            this.dgvMatches.TabIndex = 3;
            // 
            // btnCreatePdf
            // 
            this.btnCreatePdf.Location = new System.Drawing.Point(955, 45);
            this.btnCreatePdf.Name = "btnCreatePdf";
            this.btnCreatePdf.Size = new System.Drawing.Size(148, 36);
            this.btnCreatePdf.TabIndex = 4;
            this.btnCreatePdf.Text = "Create pdf";
            this.btnCreatePdf.UseVisualStyleBackColor = true;
            this.btnCreatePdf.Click += new System.EventHandler(this.btnCreatePdf_Click);
            // 
            // RangListsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 537);
            this.Controls.Add(this.btnCreatePdf);
            this.Controls.Add(this.dgvMatches);
            this.Controls.Add(this.btnYellowCards);
            this.Controls.Add(this.btnGoals);
            this.Controls.Add(this.dgvPlayers);
            this.Name = "RangListsForm";
            this.Text = "RangListsForm";
            this.Load += new System.EventHandler(this.RangListsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvPlayers;
        private Button btnGoals;
        private Button btnYellowCards;
        private DataGridView dgvMatches;
        private Button btnCreatePdf;
    }
}