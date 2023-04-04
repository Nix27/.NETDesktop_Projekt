using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class RankedMatch
    {
        public string Location { get; set; }
        public long Attendance { get; set; }
        public string HomeCountry { get; set; }
        public string AwayCountry { get; set; }
    }
}
