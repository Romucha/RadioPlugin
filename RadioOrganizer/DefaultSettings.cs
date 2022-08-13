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
                    defaultradioStations = new Dictionary<string, string>()
                    {
                        { "Серебряный дождь", "http://213.59.4.27:8000/silver128.mp3"},
                        { "Радио Русский Рок", "https://3.stream.radiosignal.one/top100-mp3"},
                        { "Кыргызстан Обондору", "http://31.192.250.52:8000/obondoru128"},
                    };
                }
                return defaultradioStations;
            }
        }
    }
}
