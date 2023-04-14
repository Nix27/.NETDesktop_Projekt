using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public static class Links
    {
        //API
        public const string MEN_ALL_TEAMS_LINK = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string WOMEN_ALL_TEAMS_LINK = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string MEN_ALL_MATCHES_LINK = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string WOMEN_ALL_MATCHES_LINK = "https://worldcup-vua.nullbit.hr/women/matches";

        //JSON
        public const string MEN_ALL_TEAMS_JSON = @"..\..\..\..\DataAccessLayer\json\men\results.json";
        public const string WOMEN_ALL_TEAMS_JSON = @"..\..\..\..\DataAccessLayer\json\women\results.json";
        public const string MEN_ALL_MATCHES_JSON = @"..\..\..\..\DataAccessLayer\json\men\matches.json";
        public const string WOMEN_ALL_MATCHES_JSON = @"..\..\..\..\DataAccessLayer\json\women\matches.json";
    }
}
