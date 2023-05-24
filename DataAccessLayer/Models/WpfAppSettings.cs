using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class WpfAppSettings : AppSettings, IFileFormattable<WpfAppSettings>
    {
        public WindowSize? WindowSize { get; set; }

        public override string ForFileLine() => base.ForFileLine() + $"{Del}{WindowSize}";

        WpfAppSettings IFileFormattable<WpfAppSettings>.FromFileLine(string line)
        {
            var settings = line.Split(Del);
            return new WpfAppSettings
            {
                Championship = settings[0],
                Language = settings[1],
                WindowSize = new WindowSize
                {
                    Width = int.Parse(settings[2]),
                    Height = int.Parse(settings[3])
                }
            };
        }
    }
}
