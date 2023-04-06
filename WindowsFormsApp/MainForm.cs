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
    public partial class MainForm : Form
    {
        private Form activeForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenNewForm(Form childForm, object sender)
        {
            if(activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlMainContainer.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenNewForm(new Form1(), sender);
        }

        private void btnRangLists_Click(object sender, EventArgs e)
        {
            OpenNewForm(new RangListsForm(), sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenNewForm(new Settings(), sender);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenNewForm(new Form1(), sender);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.CostumMessageBoxForm msgBoxFrom = new Forms.CostumMessageBoxForm();

            msgBoxFrom.SetTitleAndQuestion("Exit", "Are you sure you want to exit the application?");
            msgBoxFrom.AcceptButton = msgBoxFrom.Controls.Find("btnYes", false).FirstOrDefault() as Button;
            msgBoxFrom.CancelButton = msgBoxFrom.Controls.Find("btnNo", false).FirstOrDefault() as Button;

            if (msgBoxFrom.ShowDialog() == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
