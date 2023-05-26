using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp.User_controls
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }

        private string profilePicture;
        private string playerName;
        private int number;

        public string ProfilePicture
        {
            get { return profilePicture; }
            set
            {
                profilePicture = value;

                string currentDirectory = Environment.CurrentDirectory;
                string filePath = System.IO.Path.Combine(currentDirectory, value);

                playerProfilePic.Source = new BitmapImage(new Uri(filePath, UriKind.Absolute));
            }
        }

        public string PlayerName
        {
            get { return playerName; }
            set
            {
                playerName = value;
                lbPlayerName.Content = value;
            }
        }

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                lbShirtNumber.Content = value;
            }
        }

        public string Position { get; set; }
        public bool Captain { get; set; }
    }
}
