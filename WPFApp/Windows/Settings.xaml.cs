using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Resources;

namespace WPFApp.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private FileRepository<WpfAppSettings> appSettingsRepo = new FileRepository<WpfAppSettings>(FilePaths.WPF_APP_SETTINGS_PATH);
        string language;

        public Settings()
        {
            InitializeComponent();

            if (!File.Exists(FilePaths.WPF_APP_SETTINGS_PATH))
            {
                cmbChampionships.SelectedIndex = 0;
                cmbLanguages.SelectedIndex = 0;
                rbDefault.IsChecked = true;
            }
            else
            {
                var loadedSettings = appSettingsRepo.LoadSingle();
                SetSettings(loadedSettings);
            }

            language = appSettingsRepo.LoadSingle().Language;
            LanguageUtility.SetNewLanguage(language, SetCulture);
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            ResourceManager rm = new ResourceManager("WPFApp.Languages.SettingsLanguages.Resource", Assembly.GetExecutingAssembly());
            lbChampionship.Content = rm.GetString("lbChampionship");
            lbLanguage.Content = rm.GetString("lbLanguage");
            lbSize.Content = rm.GetString("lbSize");
            rbDefault.Content = rm.GetString("rbDefault");
            btnApply.Content = rm.GetString("btnApply");
            btnCancel.Content = rm.GetString("btnCancel");
            itMen.Content = rm.GetString("itMen");
            itWomen.Content = rm.GetString("itWomen");
            itCroatian.Content = rm.GetString("itCroatian");
            itEnglish.Content = rm.GetString("itEnglish");
            this.Title = rm.GetString("title");
        }


        private void SetSettings(WpfAppSettings settings)
        {
            if (settings.Championship == Constants.MEN_REPRESENTATION_CRO || settings.Championship == Constants.MEN_REPRESENTATION_ENG)
                cmbChampionships.SelectedIndex = 0;
            else
                cmbChampionships.SelectedIndex = 1;

            if (settings.Language == Constants.CROATIAN_LANGUAGE_CRO || settings.Language == Constants.CROATIAN_LANGUAGE_ENG)
                cmbLanguages.SelectedIndex = 0;
            else
                cmbLanguages.SelectedIndex = 1;

            WindowSize? size = settings.WindowSize;

            if (size == null)
                rbFullScreen.IsChecked = true;
            else
            {
                if (size.Value.Width == 800)
                    rbDefault.IsChecked = true;

                if (size.Value.Width == 1024)
                    rb1024x768.IsChecked = true;

                if (size.Value.Width == 700)
                    rb700x700.IsChecked = true;
            }
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

            settings.Championship = (cmbChampionships.SelectedItem as ComboBoxItem).Content.ToString();
            settings.Language = (cmbLanguages.SelectedItem as ComboBoxItem).Content.ToString();

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
            MessageDialog messageDialog = new MessageDialog();

            messageDialog.SetTitleAndMessage("Are you sure?", "Are you sure you want to apply this settings?");

            if(messageDialog.ShowDialog() == true)
            { 
                DialogResult = true;
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
