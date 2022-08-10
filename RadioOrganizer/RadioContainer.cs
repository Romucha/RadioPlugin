using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
                volume = value;
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
        }

        public void StationsFromJson()
        {
            try
            {
                RadioStations = JsonConvert.DeserializeObject<ObservableCollection<RadioStationContainer>>(StationsPath);
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
    }
}
