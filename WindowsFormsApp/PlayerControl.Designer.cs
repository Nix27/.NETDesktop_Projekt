namespace WindowsFormsApp
{
    partial class PlayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPlayerProfile = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayerProfile
            // 
            this.pbPlayerProfile.Location = new System.Drawing.Point(3, 3);
            this.pbPlayerProfile.Name = "pbPlayerProfile";
            this.pbPlayerProfile.Size = new System.Drawing.Size(61, 59);
            this.pbPlayerProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayerProfile.TabIndex = 0;
            this.pbPlayerProfile.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(84, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(175, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(265, 24);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(50, 20);
            this.lblNumber.TabIndex = 2;
            this.lblNumber.Text = "label1";
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(344, 24);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(90, 25);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "label1";
            // 
            // lblCaptain
            // 
            this.lblCaptain.AutoSize = true;
            this.lblCaptain.Location = new System.Drawing.Point(451, 24);
            this.lblCaptain.Name = "lblCaptain";
            this.lblCaptain.Size = new System.Drawing.Size(50, 20);
            this.lblCaptain.TabIndex = 4;
            this.lblCaptain.Text = "label1";
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbPlayerProfile);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(505, 65);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbPlayerProfile;
        private Label lblName;
        private Label lblNumber;
        private Label lblPosition;
        private Label lblCaptain;
    }
}
