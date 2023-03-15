namespace WindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbRepresentation = new System.Windows.Forms.ComboBox();
            this.lblChooseRep = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbRepresentation
            // 
            this.cmbRepresentation.FormattingEnabled = true;
            this.cmbRepresentation.Location = new System.Drawing.Point(43, 89);
            this.cmbRepresentation.Name = "cmbRepresentation";
            this.cmbRepresentation.Size = new System.Drawing.Size(195, 28);
            this.cmbRepresentation.TabIndex = 0;
            this.cmbRepresentation.SelectedIndexChanged += new System.EventHandler(this.cmbRepresentation_SelectedIndexChanged);
            // 
            // lblChooseRep
            // 
            this.lblChooseRep.AutoSize = true;
            this.lblChooseRep.Location = new System.Drawing.Point(43, 50);
            this.lblChooseRep.Name = "lblChooseRep";
            this.lblChooseRep.Size = new System.Drawing.Size(161, 20);
            this.lblChooseRep.TabIndex = 4;
            this.lblChooseRep.Text = "Choose representation:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 512);
            this.Controls.Add(this.lblChooseRep);
            this.Controls.Add(this.cmbRepresentation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Football Championships";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbRepresentation;
		private Label lblChooseRep;
    }
}