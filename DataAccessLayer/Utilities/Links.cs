﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public static class Links
    {
        //API
        public const string menAllTeamsLink = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string womenAllTeamsLink = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string menAllMatchesLink = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string womenAllMatchesLink = "https://worldcup-vua.nullbit.hr/women/matches";

        //JSON
        public const string menAllTeamsJson = @"C:\Users\Nix\Documents\.NET praktikum\Nikola_Zečić_Projekt\DataAccessLayer\json\men\results.json";
        public const string womenAllTeamsJson = @"C:\Users\Nix\Documents\.NET praktikum\Nikola_Zečić_Projekt\DataAccessLayer\json\women\results.json";
        public const string menAllMatchesJson = @"C:\Users\Nix\Documents\.NET praktikum\Nikola_Zečić_Projekt\DataAccessLayer\json\men\matches.json";
        public const string womenAllMatchesJson = @"C:\Users\Nix\Documents\.NET praktikum\Nikola_Zečić_Projekt\DataAccessLayer\json\women\matches.json";
    }
}
