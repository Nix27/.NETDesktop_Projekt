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
        public int Amount { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is RankedPlayer player &&
                   Amount == player.Amount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount);
        }

        public int CompareTo(RankedPlayer? other) => Amount.CompareTo(other.Amount);

        public override string ToString()
        {
            return $"{PlayerName} {Amount}";
        }
    }
}
