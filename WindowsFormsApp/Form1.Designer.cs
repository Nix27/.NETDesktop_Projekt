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
            this.flpPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpFavouritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPlayersHeader = new System.Windows.Forms.Panel();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlFavouritePlayersHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFavouritePlayers = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.pnlPlayersHeader.SuspendLayout();
            this.pnlFavouritePlayersHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRepresentation
            // 
            this.cmbRepresentation.FormattingEnabled = true;
            this.cmbRepresentation.Location = new System.Drawing.Point(43, 48);
            this.cmbRepresentation.Name = "cmbRepresentation";
            this.cmbRepresentation.Size = new System.Drawing.Size(195, 28);
            this.cmbRepresentation.TabIndex = 0;
            this.cmbRepresentation.SelectedIndexChanged += new System.EventHandler(this.cmbRepresentation_SelectedIndexChanged);
            // 
            // lblChooseRep
            // 
            this.lblChooseRep.AutoSize = true;
            this.lblChooseRep.Location = new System.Drawing.Point(43, 9);
            this.lblChooseRep.Name = "lblChooseRep";
            this.lblChooseRep.Size = new System.Drawing.Size(161, 20);
            this.lblChooseRep.TabIndex = 4;
            this.lblChooseRep.Text = "Choose representation:";
            // 
            // flpPlayers
            // 
            this.flpPlayers.AllowDrop = true;
            this.flpPlayers.AutoScroll = true;
            this.flpPlayers.Location = new System.Drawing.Point(44, 189);
            this.flpPlayers.Name = "flpPlayers";
            this.flpPlayers.Size = new System.Drawing.Size(540, 302);
            this.flpPlayers.TabIndex = 5;
            this.flpPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flp_DragDrop);
            this.flpPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flp_DragEnter);
            // 
            // flpFavouritePlayers
            // 
            this.flpFavouritePlayers.AllowDrop = true;
            this.flpFavouritePlayers.AutoScroll = true;
            this.flpFavouritePlayers.Location = new System.Drawing.Point(642, 189);
            this.flpFavouritePlayers.Name = "flpFavouritePlayers";
            this.flpFavouritePlayers.Size = new System.Drawing.Size(540, 302);
            this.flpFavouritePlayers.TabIndex = 6;
            this.flpFavouritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flp_DragDrop);
            this.flpFavouritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flp_DragEnter);
            // 
            // pnlPlayersHeader
            // 
            this.pnlPlayersHeader.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlPlayersHeader.Controls.Add(this.lblCaptain);
            this.pnlPlayersHeader.Controls.Add(this.lblPosition);
            this.pnlPlayersHeader.Controls.Add(this.lblShirtNumber);
            this.pnlPlayersHeader.Controls.Add(this.lblName);
            this.pnlPlayersHeader.Location = new System.Drawing.Point(43, 145);
            this.pnlPlayersHeader.Name = "pnlPlayersHeader";
            this.pnlPlayersHeader.Size = new System.Drawing.Size(540, 38);
            this.pnlPlayersHeader.TabIndex = 7;
            // 
            // lblCaptain
            // 
            this.lblCaptain.AutoSize = true;
            this.lblCaptain.Location = new System.Drawing.Point(423, 9);
            this.lblCaptain.Name = "lblCaptain";
            this.lblCaptain.Size = new System.Drawing.Size(60, 20);
            this.lblCaptain.TabIndex = 3;
            this.lblCaptain.Text = "Captain";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(332, 9);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(61, 20);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Position";
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.AutoSize = true;
            this.lblShirtNumber.Location = new System.Drawing.Point(237, 9);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(63, 20);
            this.lblShirtNumber.TabIndex = 1;
            this.lblShirtNumber.Text = "Number";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(84, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // pnlFavouritePlayersHeader
            // 
            this.pnlFavouritePlayersHeader.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlFavouritePlayersHeader.Controls.Add(this.label1);
            this.pnlFavouritePlayersHeader.Controls.Add(this.label2);
            this.pnlFavouritePlayersHeader.Controls.Add(this.label3);
            this.pnlFavouritePlayersHeader.Controls.Add(this.label4);
            this.pnlFavouritePlayersHeader.Location = new System.Drawing.Point(642, 145);
            this.pnlFavouritePlayersHeader.Name = "pnlFavouritePlayersHeader";
            this.pnlFavouritePlayersHeader.Size = new System.Drawing.Size(540, 38);
            this.pnlFavouritePlayersHeader.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Captain";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Position";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name";
            // 
            // lblFavouritePlayers
            // 
            this.lblFavouritePlayers.AutoSize = true;
            this.lblFavouritePlayers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFavouritePlayers.Location = new System.Drawing.Point(642, 114);
            this.lblFavouritePlayers.Name = "lblFavouritePlayers";
            this.lblFavouritePlayers.Size = new System.Drawing.Size(174, 28);
            this.lblFavouritePlayers.TabIndex = 9;
            this.lblFavouritePlayers.Text = "Favourite Players";
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlayers.Location = new System.Drawing.Point(43, 114);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(80, 28);
            this.lblPlayers.TabIndex = 10;
            this.lblPlayers.Text = "Players";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 512);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.lblFavouritePlayers);
            this.Controls.Add(this.pnlFavouritePlayersHeader);
            this.Controls.Add(this.pnlPlayersHeader);
            this.Controls.Add(this.flpFavouritePlayers);
            this.Controls.Add(this.flpPlayers);
            this.Controls.Add(this.lblChooseRep);
            this.Controls.Add(this.cmbRepresentation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Football Championships";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlPlayersHeader.ResumeLayout(false);
            this.pnlPlayersHeader.PerformLayout();
            this.pnlFavouritePlayersHeader.ResumeLayout(false);
            this.pnlFavouritePlayersHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbRepresentation;
		private Label lblChooseRep;
        private FlowLayoutPanel flpPlayers;
        private FlowLayoutPanel flpFavouritePlayers;
        private Panel pnlPlayersHeader;
        private Label lblName;
        private Label lblShirtNumber;
        private Label lblPosition;
        private Label lblCaptain;
        private Panel pnlFavouritePlayersHeader;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblFavouritePlayers;
        private Label lblPlayers;
    }
}