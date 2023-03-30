using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class RankedPlayer
    {
        public string ProfileURL { get; set; }
        public string PlayerName { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{PlayerName} {Amount}";
        }
    }
}
