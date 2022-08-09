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

        private ImageSource logo;
        public ImageSource Logo
        {
            get => logo;
            set
            {
                logo = value;
            }
        }

        public RadioStationContainer(string Name, string Url, string LogoPath)
        {
            this.Name = Name;
            this.Url = Url;
            SetLogo(LogoPath);
        }

        public void SetLogo(string LogoPath)
        {
            try
            {
                Logo = new BitmapImage(new Uri(LogoPath));
            }
            catch
            {
                Logo = new BitmapImage(new Uri("Logos\\_default.png"));
            }
        }
    }
}
