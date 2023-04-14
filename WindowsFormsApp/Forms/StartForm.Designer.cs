namespace WindowsFormsApp
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
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
            this.pbLoader = new System.Windows.Forms.PictureBox();
            this.pnlPlayersHeader.SuspendLayout();
            this.pnlFavouritePlayersHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRepresentation
            // 
            resources.ApplyResources(this.cmbRepresentation, "cmbRepresentation");
            this.cmbRepresentation.BackColor = System.Drawing.SystemColors.Control;
            this.cmbRepresentation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbRepresentation.FormattingEnabled = true;
            this.cmbRepresentation.Name = "cmbRepresentation";
            this.cmbRepresentation.SelectedIndexChanged += new System.EventHandler(this.cmbRepresentation_SelectedIndexChanged);
            // 
            // lblChooseRep
            // 
            resources.ApplyResources(this.lblChooseRep, "lblChooseRep");
            this.lblChooseRep.BackColor = System.Drawing.SystemColors.Control;
            this.lblChooseRep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChooseRep.Name = "lblChooseRep";
            // 
            // flpPlayers
            // 
            resources.ApplyResources(this.flpPlayers, "flpPlayers");
            this.flpPlayers.AllowDrop = true;
            this.flpPlayers.Name = "flpPlayers";
            this.flpPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flp_DragDrop);
            this.flpPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flp_DragEnter);
            // 
            // flpFavouritePlayers
            // 
            resources.ApplyResources(this.flpFavouritePlayers, "flpFavouritePlayers");
            this.flpFavouritePlayers.AllowDrop = true;
            this.flpFavouritePlayers.Name = "flpFavouritePlayers";
            this.flpFavouritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flp_DragDrop);
            this.flpFavouritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flp_DragEnter);
            // 
            // pnlPlayersHeader
            // 
            resources.ApplyResources(this.pnlPlayersHeader, "pnlPlayersHeader");
            this.pnlPlayersHeader.BackColor = System.Drawing.Color.Silver;
            this.pnlPlayersHeader.Controls.Add(this.lblCaptain);
            this.pnlPlayersHeader.Controls.Add(this.lblPosition);
            this.pnlPlayersHeader.Controls.Add(this.lblShirtNumber);
            this.pnlPlayersHeader.Controls.Add(this.lblName);
            this.pnlPlayersHeader.Name = "pnlPlayersHeader";
            // 
            // lblCaptain
            // 
            resources.ApplyResources(this.lblCaptain, "lblCaptain");
            this.lblCaptain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCaptain.Name = "lblCaptain";
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPosition.Name = "lblPosition";
            // 
            // lblShirtNumber
            // 
            resources.ApplyResources(this.lblShirtNumber, "lblShirtNumber");
            this.lblShirtNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblShirtNumber.Name = "lblShirtNumber";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblName.Name = "lblName";
            // 
            // pnlFavouritePlayersHeader
            // 
            resources.ApplyResources(this.pnlFavouritePlayersHeader, "pnlFavouritePlayersHeader");
            this.pnlFavouritePlayersHeader.BackColor = System.Drawing.Color.Silver;
            this.pnlFavouritePlayersHeader.Controls.Add(this.label1);
            this.pnlFavouritePlayersHeader.Controls.Add(this.label2);
            this.pnlFavouritePlayersHeader.Controls.Add(this.label3);
            this.pnlFavouritePlayersHeader.Controls.Add(this.label4);
            this.pnlFavouritePlayersHeader.Name = "pnlFavouritePlayersHeader";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Name = "label4";
            // 
            // lblFavouritePlayers
            // 
            resources.ApplyResources(this.lblFavouritePlayers, "lblFavouritePlayers");
            this.lblFavouritePlayers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFavouritePlayers.Name = "lblFavouritePlayers";
            // 
            // lblPlayers
            // 
            resources.ApplyResources(this.lblPlayers, "lblPlayers");
            this.lblPlayers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPlayers.Name = "lblPlayers";
            // 
            // pbLoader
            // 
            resources.ApplyResources(this.pbLoader, "pbLoader");
            this.pbLoader.Image = global::WindowsFormsApp.Properties.Resources.loader;
            this.pbLoader.Name = "pbLoader";
            this.pbLoader.TabStop = false;
            // 
            // StartForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pbLoader);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.lblFavouritePlayers);
            this.Controls.Add(this.pnlFavouritePlayersHeader);
            this.Controls.Add(this.pnlPlayersHeader);
            this.Controls.Add(this.flpFavouritePlayers);
            this.Controls.Add(this.flpPlayers);
            this.Controls.Add(this.lblChooseRep);
            this.Controls.Add(this.cmbRepresentation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlPlayersHeader.ResumeLayout(false);
            this.pnlPlayersHeader.PerformLayout();
            this.pnlFavouritePlayersHeader.ResumeLayout(false);
            this.pnlFavouritePlayersHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoader)).EndInit();
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
        private PictureBox pbLoader;
    }
}