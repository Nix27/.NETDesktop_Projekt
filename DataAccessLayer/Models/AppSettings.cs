using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class AppSettings
    {
        private const char Del = ';';

        private readonly IList<string> championships = new List<string> { "Men", "Women" };

        private IList<string> languages = new List<string> { "Croatian", "English" };

        public IList<string> Championships
        {
            get => new List<string>(championships);
        }

        public IList<string> Languages
        {
            get => new List<string>(languages);
        }

        public string Championship { get; set; }
        public string Language { get; set; }

        public string ParseForFileLine() => $"{Championship}{Del}{Language}";

        public static AppSettings ParseFromFileLine(string line)
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
