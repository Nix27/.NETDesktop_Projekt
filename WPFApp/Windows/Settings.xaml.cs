using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        public WpfAppSettings GetSettings()
        {
            string selectedSize = "";
            WpfAppSettings settings = new WpfAppSettings();

            foreach (var rb in spRadioButtons.Children.OfType<RadioButton>())
            {
                if (rb.IsChecked == true)
                {
                    selectedSize = rb.Tag.ToString();
                }
            }

            settings.Championship = cmbChampionships.SelectedItem.ToString();
            settings.Language = cmbChampionships.SelectedItem.ToString();

            if(selectedSize != "FullScreen")
            {
                var widthHeight = selectedSize.Split(';');
                settings.WindowSize = new WindowSize
                {
                    Width = int.Parse(widthHeight[0]),
                    Height = int.Parse(widthHeight[1])
                };
            }

            return settings;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
