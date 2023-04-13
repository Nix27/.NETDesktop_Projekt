using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public static class ConfigUtility
    {
        public static string ReadConfig()
        {
            return File.ReadAllText(FilePaths.configPath);
        }
    }
}
