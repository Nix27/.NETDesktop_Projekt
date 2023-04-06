using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class RankedPlayer : IComparable<RankedPlayer>
    {
        public string ProfileURL { get; set; }
        public string PlayerName { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is RankedPlayer player &&
                   Goals == player.Goals;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Goals);
        }

        public int CompareTo(RankedPlayer? other) => Goals.CompareTo(other.Goals);

        public override string ToString()
        {
            return $"{PlayerName} {Goals}";
        }
    }
}
