using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AppSettingsFileRepository : FileRepository, IFileRepository<AppSettings>
    {
        public AppSettingsFileRepository(string path) : base(path)
        {
        }

        public AppSettings Load()
        {
            var settings = File.ReadAllText(PATH);
            return AppSettings.ParseFromFileLine(settings);
        }

        public void Save(AppSettings aps)
        {
            File.WriteAllText(PATH, aps.ParseForFileLine());
        }
    }
}
