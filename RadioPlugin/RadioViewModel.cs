using RadioOrganizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RadioPlugin
{
    public class RadioViewModel : INotifyPropertyChanged
    {
        //Property changed
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }        

        private RadioContainer radioContainer;

        public RadioContainer RadioContainer
        {
            get => radioContainer;
            set
            {
                radioContainer = value;
                OnPropertyChanged(nameof(RadioContainer));
            }
        }

        public int Volume
        {
            get => RadioContainer.Volume;
            set
            {
                if (RadioContainer != null)
                    RadioContainer.Volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }

        public RadioViewModel()
        {
            RadioContainer = new RadioContainer();
        }
    }
}
