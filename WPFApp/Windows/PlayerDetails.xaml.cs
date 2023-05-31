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
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Window
    {
        private FileRepository<WpfAppSettings> appSettingsRepo = new FileRepository<WpfAppSettings>(FilePaths.WPF_APP_SETTINGS_PATH);

        public PlayerDetails()
        {
            InitializeComponent();
            DataContext = new Player();

            string language = appSettingsRepo.LoadSingle().Language;
            LanguageUtility.SetNewLanguage(language, SetCulture);
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            ResourceManager rm = new ResourceManager("WPFApp.Languages.PlayerDetailsLanguages.Resource", Assembly.GetExecutingAssembly());
            lbName.Content = rm.GetString("lbName");
            lbNumber.Content = rm.GetString("lbNumber");
            lbPosition.Content = rm.GetString("lbPosition");
            lbCaptain.Content = rm.GetString("lbCaptain");
            lbGoals.Content = rm.GetString("lbGoals");
            lbYellowCards.Content = rm.GetString("lbYellowCards");
            btnClose.Content = rm.GetString("btnClose");
            this.Title = rm.GetString("title");
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
