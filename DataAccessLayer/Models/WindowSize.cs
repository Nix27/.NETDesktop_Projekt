using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public struct WindowSize
    {
        private const char Del = ';';
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString() => $"{Width}{Del}{Height}";
    }
}
