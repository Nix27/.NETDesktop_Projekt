using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public static class FilePaths
    {
        public const string configPath = @"..\..\..\..\DataAccessLayer\appfiles\Config.txt";
        public const string appSettingsPath = @"..\..\..\..\DataAccessLayer\appfiles\AppSettings.txt";
        public const string selectedMenTeamPath = @"..\..\..\..\DataAccessLayer\appfiles\SelectedTeam\SelectedMenTeam.txt";
        public const string selectedWomenTeamPath = @"..\..\..\..\DataAccessLayer\appfiles\SelectedTeam\SelectedWomenTeam.txt";
        public const string menPlayersPath = @"..\..\..\..\DataAccessLayer\appfiles\Players\Men\";
        public const string womenPlayersPath = @"..\..\..\..\DataAccessLayer\appfiles\Players\Women\";
        public const string imagesPath = @"..\..\..\..\DataAccessLayer\images";
    }
}
