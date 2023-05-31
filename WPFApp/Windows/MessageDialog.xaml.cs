using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Resources;

namespace WPFApp.Windows
{
    /// <summary>
    /// Interaction logic for MessageDialog.xaml
    /// </summary>
    public partial class MessageDialog : Window
    {
        private FileRepository<WpfAppSettings> appSettingsRepo = new FileRepository<WpfAppSettings>(FilePaths.WPF_APP_SETTINGS_PATH);
        public MessageDialog()
        {
            InitializeComponent();

            string language = appSettingsRepo.LoadSingle().Language;
            LanguageUtility.SetNewLanguage(language, SetCulture);
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            ResourceManager rm = new ResourceManager("WPFApp.Languages.MessageDialogLanguages.Resource", Assembly.GetExecutingAssembly());
            btnYes.Content = rm.GetString("btnYes");
            btnNo.Content = rm.GetString("btnNo");
        }

        public void SetTitleAndMessage(string title, string msg)
        {
            this.Title = title;
            lbMessage.Content = msg;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
