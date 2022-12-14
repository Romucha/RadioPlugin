using Ascon.AU.PluginConnector;
using RadioOrganizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RadioPlugin
{
    /// <summary>
    /// Логика взаимодействия для RadioControl.xaml
    /// </summary>
    public partial class RadioControl : UserControl, IPlugin
    {
        public string DisplayName { get; set; } = "Радио";
        public string Description { get; set; } = "Радио";
        public string PluginID { get; set; } = "RadioPlugin";
        public int DisplayIconCode { get; set; } = 0xe022;
        public string HelpLink { get; set; } = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
        public string UpdateCommandDescription { get; set; }
        public string ExpressPanelCommandDescription { get; set; }
        public string Command3Description { get; set; }
        public string Command4Description { get; set; }
        public string Command5Description { get; set; }
        public string Command1Description { get; set; }
        public string Command2Description { get; set; }

        public event EventHandler<ToastNotificationEventArgs> OnShowToastNotification;

        public UserControl GetPlugin() => this;

        public RadioViewModel ViewModel;

        public void Initialize()
        {
            ViewModel = new RadioViewModel();
            this.DataContext = ViewModel;
        }

        public void Terminate()
        {
            
        }

        public void UpdateCommand()
        {
            
        }

        public void ExpressPanelCommand()
        {

        }

        public void Command1()
        {

        }

        public void Command2()
        {

        }

        public void Command3()
        {
            
        }

        public void Command4()
        {
            
        }

        public void Command5()
        {
            
        }

        public RadioControl()
        {
            InitializeComponent();
        }

        private void ply_btn_Click(object sender, RoutedEventArgs e)
        {
            /*
                Updated algorythm:
                1. Regardless of the player state we stop it (all stations aren't playing anymore)
                2. If the station isn't playing we start it
             */
            //REWORK EVERYTHING
            var bufRadioStation = ((FrameworkElement)sender).DataContext as RadioStationContainer;
            bool isplaying = bufRadioStation.IsPlaying;            
            if (isplaying)
            {
                ViewModel.RadioContainer.Stop();
            }
            else
            {
                ViewModel.RadioContainer.Play(bufRadioStation);
            }
        }
    }
}
