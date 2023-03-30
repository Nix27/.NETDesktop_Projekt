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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Location = new System.Drawing.Point(39, 103);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.RowHeadersWidth = 51;
            this.dgvPlayers.RowTemplate.Height = 29;
            this.dgvPlayers.Size = new System.Drawing.Size(584, 386);
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
            // 
            // btnYellowCards
            // 
            this.btnYellowCards.Location = new System.Drawing.Point(193, 45);
            this.btnYellowCards.Name = "btnYellowCards";
            this.btnYellowCards.Size = new System.Drawing.Size(148, 36);
            this.btnYellowCards.TabIndex = 2;
            this.btnYellowCards.Text = "Yellow cards";
            this.btnYellowCards.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(688, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(584, 386);
            this.dataGridView1.TabIndex = 3;
            // 
            // RangListsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 537);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnYellowCards);
            this.Controls.Add(this.btnGoals);
            this.Controls.Add(this.dgvPlayers);
            this.Name = "RangListsForm";
            this.Text = "RangListsForm";
            this.Load += new System.EventHandler(this.RangListsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvPlayers;
        private Button btnGoals;
        private Button btnYellowCards;
        private DataGridView dataGridView1;
    }
}