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
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Window
    {
        public PlayerDetails()
        {
            InitializeComponent();
            DataContext = new Player();
        }

        public ImageSource PlayerPicture { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
