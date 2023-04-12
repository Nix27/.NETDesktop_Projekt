using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class AppSettings : IFileFormattable<AppSettings>
    {
        private const char Del = ';';

        public string Championship { get; set; }
        public string Language { get; set; }

        public string ForFileLine() => $"{Championship}{Del}{Language}";

        public AppSettings FromFileLine(string line)
        {
            var settings = line.Split(Del);

            return new AppSettings
            {
                Championship = settings[0],
                Language = settings[1]
            };
        }
    }
}
