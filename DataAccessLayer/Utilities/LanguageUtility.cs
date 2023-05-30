using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public static class LanguageUtility
    {
        public delegate void ChangeLanguage(string culture);
        public static void SetNewLanguage(string lng, ChangeLanguage methodForChangeLanguage)
        {
            string culture = lng == Constants.CROATIAN_LANGUAGE_ENG || lng == Constants.CROATIAN_LANGUAGE_CRO ? "hr-HR" : "en-US";
            methodForChangeLanguage(culture);
        }
    }
}
