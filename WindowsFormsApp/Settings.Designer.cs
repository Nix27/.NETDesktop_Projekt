namespace WindowsFormsApp
{
    partial class Settings
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
            this.lblChampion = new System.Windows.Forms.Label();
            this.cmbChampionships = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguages = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChampion
            // 
            this.lblChampion.AutoSize = true;
            this.lblChampion.Location = new System.Drawing.Point(20, 59);
            this.lblChampion.Name = "lblChampion";
            this.lblChampion.Size = new System.Drawing.Size(80, 20);
            this.lblChampion.TabIndex = 0;
            this.lblChampion.Text = "Champion:";
            // 
            // cmbChampionships
            // 
            this.cmbChampionships.FormattingEnabled = true;
            this.cmbChampionships.Location = new System.Drawing.Point(126, 56);
            this.cmbChampionships.Name = "cmbChampionships";
            this.cmbChampionships.Size = new System.Drawing.Size(207, 28);
            this.cmbChampionships.TabIndex = 1;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(20, 122);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(77, 20);
            this.lblLanguage.TabIndex = 2;
            this.lblLanguage.Text = "Language:";
            // 
            // cmbLanguages
            // 
            this.cmbLanguages.FormattingEnabled = true;
            this.cmbLanguages.Location = new System.Drawing.Point(126, 119);
            this.cmbLanguages.Name = "cmbLanguages";
            this.cmbLanguages.Size = new System.Drawing.Size(207, 28);
            this.cmbLanguages.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(126, 170);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 29);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(239, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 246);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbLanguages);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cmbChampionships);
            this.Controls.Add(this.lblChampion);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblChampion;
        private ComboBox cmbChampionships;
        private Label lblLanguage;
        private ComboBox cmbLanguages;
        private Button btnOk;
        private Button btnCancel;
    }
}