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
    public partial class RangListsForm : Form
    {
        private Form1 f1 = new Form1();
        public RangListsForm()
        {
            InitializeComponent();
        }

        private void RangListsForm_Load(object sender, EventArgs e)
        {
            var rankedPlayers = f1.GetPlayersByGoals();
        }
    }
}
