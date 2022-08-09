using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioOrganizer
{
    public class Settings
    {
        private static Dictionary<string, string> DefaultSettings;

        static Settings()
        {
            DefaultSettings = new Dictionary<string, string>()
            {

            };
        }

        private Dictionary<string, string> radioStations;

        public Dictionary<string, string> RadioStations
        {
            get => radioStations;
            set
            {
                radioStations = value;
            }
        }
    }
}
