using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioOrganizer
{
    public class RadioContainer
    {
        private ObservableCollection<RadioStationContainer> radioStations;
        public ObservableCollection<RadioStationContainer> RadioStations
        {
            get=> radioStations;
            set
            {
                radioStations = value;
            }
        }
    }
}
