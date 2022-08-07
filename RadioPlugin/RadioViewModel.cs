using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WMPLib;

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

        private WindowsMediaPlayer wmp;
        public WindowsMediaPlayer WMP
        {
            get => wmp;
            set
            {
                wmp = value;
                OnPropertyChanged(nameof(WMP));
            }
        }

        private int volume = 100;
        public int Volume
        {
            get => volume;
            set
            {
                volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }

        private string url = "http://213.59.4.27:8000/silver128.mp3";
        public string URL
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged(nameof(URL));
            }
        }

        public RadioViewModel()
        {
            WMP = new WindowsMediaPlayer();
        }

        public void Start()
        {
            WMP.URL = URL;
            WMP.settings.volume = Volume;
            //WMP.controls.play();
            Task play = new Task(WMP.controls.play);
            play.Start();
        }

        public void Stop()
        {
            if (wmp.playState == WMPPlayState.wmppsPlaying)
            {
                WMP.controls.stop();
            }
        }
    }
}
