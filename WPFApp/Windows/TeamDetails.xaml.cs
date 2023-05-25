using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp.Windows
{
    /// <summary>
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        public TeamDetails()
        {
            InitializeComponent();
            DataContext = new NationalTeam();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
