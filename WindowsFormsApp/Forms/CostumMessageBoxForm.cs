using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.Forms
{
    public partial class CostumMessageBoxForm : Form
    {
        public CostumMessageBoxForm()
        {
            InitializeComponent();
        }

        public void SetTitleAndQuestion(string title, string question)
        {
            this.Text = title;
            lblQuestion.Text = question;
        }
    }
}
