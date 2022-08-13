using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WMPLib;

namespace RadioOrganizer
{
    public class RadioContainer
    {
        private static string StationsPath
        {
            get
            {
                string dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ascon.AU.MetaData", "Radio Plugin");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                return Path.Combine(dirPath, "RadioStations.json");
            }
        }

        private WindowsMediaPlayer wmp;
        public WindowsMediaPlayer WMP
        {
            get => wmp;
            set
            {
                wmp = value;                
            }
        }

        private ObservableCollection<RadioStationContainer> radioStations;
        public ObservableCollection<RadioStationContainer> RadioStations
        {
            get=> radioStations;
            set
            {
                radioStations = value;
            }
        }

        private int volume = 100;        
        public int Volume
        {
            get => volume;
            set
            {
                if (value > 0 && value <= 100)
                {
                    WMP.settings.volume = value;
                    volume = value;
                }
            }
        }

        public RadioContainer()
        {
            if (!File.Exists(StationsPath))
            {
                RadioStations = new ObservableCollection<RadioStationContainer>(DefaultSettings.DefaultRadioStations.Select(c=> new RadioStationContainer(c.Key, c.Value)));
                StationsToJson();
            }
            else
            {
                StationsFromJson();
            }
            WMP = new WindowsMediaPlayer();
        }

        public void StationsFromJson()
        {
            try
            {
                RadioStations = JsonConvert.DeserializeObject<ObservableCollection<RadioStationContainer>>(File.ReadAllText(StationsPath));
            }
            catch (Exception ex)
            {

            }
        }

        public void StationsToJson()
        {
            try
            {
                File.WriteAllText(StationsPath, JsonConvert.SerializeObject(RadioStations));
            }
            catch (Exception ex)
            {

            }
        }

        public void Play(RadioStationContainer RSC)
        {
            if (RSC != null)
            {
                if (WMP.playState != WMPPlayState.wmppsPlaying)
                {
                    WMP.URL = RSC.Url;
                    WMP.settings.volume = Volume;
                    Task play = new Task(WMP.controls.play);
                    play.Start();
                }
            }
        }

        public void Pause()
        {
            if (WMP.playState != WMPPlayState.wmppsPaused)
            {
                Task pause = new Task(WMP.controls.pause);
                pause.Start();
            }
        }

        public void Stop()
        {
            if (WMP.playState == WMPPlayState.wmppsPlaying
                || WMP.playState == WMPPlayState.wmppsPaused)
            {
                Task stop = new Task(WMP.controls.stop);
                stop.Start();
            }

        }
    }
}
