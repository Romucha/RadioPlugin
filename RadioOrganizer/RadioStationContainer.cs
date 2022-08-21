using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RadioOrganizer
{
    public class RadioStationContainer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        private void OnPropertyChanged([CallerMemberName]string name ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string name;
        public string Name
        {
            get => name;
            set 
            { 
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string url;
        public string Url
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged(nameof(Url));
            }
        }

        private bool isplaying;

        public bool IsPlaying
        {
            get => isplaying;
            set
            {
                isplaying = value;
                OnPropertyChanged(nameof(IsPlaying));
            }
        }

        public RadioStationContainer(string Name, string Url)
        {
            this.Name = Name;
            this.Url = Url;
        }
    }
}
