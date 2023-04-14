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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.lblChampion = new System.Windows.Forms.Label();
            this.cmbChampionships = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguages = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChampion
            // 
            resources.ApplyResources(this.lblChampion, "lblChampion");
            this.lblChampion.Name = "lblChampion";
            // 
            // cmbChampionships
            // 
            resources.ApplyResources(this.cmbChampionships, "cmbChampionships");
            this.cmbChampionships.FormattingEnabled = true;
            this.cmbChampionships.Items.AddRange(new object[] {
            resources.GetString("cmbChampionships.Items"),
            resources.GetString("cmbChampionships.Items1")});
            this.cmbChampionships.Name = "cmbChampionships";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // cmbLanguages
            // 
            resources.ApplyResources(this.cmbLanguages, "cmbLanguages");
            this.cmbLanguages.FormattingEnabled = true;
            this.cmbLanguages.Items.AddRange(new object[] {
            resources.GetString("cmbLanguages.Items"),
            resources.GetString("cmbLanguages.Items1")});
            this.cmbLanguages.Name = "cmbLanguages";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbLanguages);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cmbChampionships);
            this.Controls.Add(this.lblChampion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
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
    }
}