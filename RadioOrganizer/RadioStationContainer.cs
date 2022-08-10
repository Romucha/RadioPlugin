using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RadioOrganizer
{
    public class RadioStationContainer
    {
        private string name;
        public string Name
        {
            get => name;
            set 
            { 
                name = value;
            }
        }

        private string url;
        public string Url
        {
            get => url;
            set
            {
                url = value;
            }
        }

        public RadioStationContainer(string Name, string Url)
        {
            this.Name = Name;
            this.Url = Url;
        }
    }
}
