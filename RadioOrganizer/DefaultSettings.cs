using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioOrganizer
{
    public static class DefaultSettings
    {

        private static Dictionary<string, string> defaultradioStations;

        public static Dictionary<string, string> DefaultRadioStations
        {
            get 
            {
                if (defaultradioStations == null)
                {
                    defaultradioStations = new Dictionary<string, string>();
                    {

                    }
                }
                return defaultradioStations;
            }
        }
    }
}
