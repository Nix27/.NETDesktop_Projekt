using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Events
{
    public class LanguageChangedEventArgs : EventArgs
    {
        public string Culture { get; set; }
    }
}
