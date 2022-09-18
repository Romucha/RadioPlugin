using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public async void Play(RadioStationContainer RSC)
        {
            if (RSC != null)
            {
                if (WMP.playState != WMPPlayState.wmppsPlaying)
                {

                    using (CancellationTokenSource cancelTokenSource = new CancellationTokenSource(5000))
                    {
                        CancellationToken token = cancelTokenSource.Token;
                        await Task.Run(() =>
                        {
                            token.Register(() =>
                            {
                                if (wmp.playState != WMPPlayState.wmppsPlaying)
                                {
                                    RSC.IsPlaying = false;
                                    WMP.controls.stop();
                                }
                                return;
                            });
                            try
                            {
                                WMP.URL = RSC.Url;
                                WMP.settings.volume = Volume;
                                RSC.IsPlaying = true;
                                WMP.controls.play();
                                Thread.Sleep(5000);
                            }
                            catch
                            {

                            }
                        }, token);
                    }
                }
            }
        }

        public async void Pause(RadioStationContainer RSC)
        {
            if (WMP.playState != WMPPlayState.wmppsPaused)
            {
                using (CancellationTokenSource cancelTokenSource = new CancellationTokenSource(5000))
                {
                    CancellationToken token = cancelTokenSource.Token;
                    await Task.Run(() =>
                    {
                        RSC.IsPlaying = false;
                        token.Register(() =>
                        {
                            RSC.IsPlaying = true;
                            return;
                        });
                        WMP.controls.pause();
                    }, token);
                }
            }
        }

        public async void Stop()
        {
            if (WMP.playState != WMPPlayState.wmppsStopped)
            {
                using (CancellationTokenSource cancelTokenSource = new CancellationTokenSource(5000))
                {
                    CancellationToken token = cancelTokenSource.Token;
                    await Task.Run(() =>
                    {
                        token.Register(() =>
                        {
                            return;
                        });
                        RadioStations.ToList().ForEach(c => c.IsPlaying = false);
                        WMP.controls.stop();
                    }, token);
                }
            }

        }
    }
}
