using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }

        private Image profile;
        private string playerName;
        private int number;
        private string position;
        private bool captain;

        [Category("PlayerControl Properties")]
        public Image Profile 
        {
            get => profile;
            set
            {
                profile = value;
                pbPlayerProfile.Image = value;
            }
        }

        [Category("PlayerControl Properties")]
        public string PlayerName
        {
            get => playerName;
            set
            {
                playerName = value;
                lblName.Text = value;
            }
        }

        [Category("PlayerControl Properties")]
        public int Number
        {
            get => number;
            set
            {
                number = value;
                lblNumber.Text = value.ToString();
            }
        }

        [Category("PlayerControl Properties")]
        public string Position
        {
            get => position;
            set
            {
                position = value;
                lblPosition.Text = value;
            }
        }

        [Category("PlayerControl Properties")]
        public bool Captain
        {
            get => captain;
            set
            {
                captain = value;
                lblCaptain.Text = value ? "Yes" : "No";
            }
        }
    }
}
