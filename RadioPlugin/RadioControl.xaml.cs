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
             * possible scenarios:
             * 1. user presses button for the very fisrt time
             * it means that current radio station == null
             * then we set current radio station to current data context
             * and play it
             * 2. user presses button after pressing another one
             * it means that current radio station != null
             * then we stop current radio station and set it to current data context
             * and play it
             * 3. user presses the same button again
             * it means user is trying to pause player and current radio station and current data context refer to the same object
             * then we stop it
             * 
             */
            var bufRadioStation = ((FrameworkElement)sender).DataContext as RadioStationContainer;
            if (ViewModel.CurrentRadioStation == null)
            {
                ViewModel.CurrentRadioStation = bufRadioStation;
                ViewModel.RadioContainer.Play(ViewModel.CurrentRadioStation);
            }
            else if (ViewModel.CurrentRadioStation != null)
            {
                if (object.ReferenceEquals(bufRadioStation, ViewModel.CurrentRadioStation))
                {
                    if (bufRadioStation.IsPlaying)
                    {
                        ViewModel.RadioContainer.Pause(bufRadioStation);
                    }
                    else
                    {
                        ViewModel.RadioContainer.Play(bufRadioStation);
                    }
                }
                else
                {
                    ViewModel.RadioContainer.Stop(ViewModel.CurrentRadioStation);
                    ViewModel.CurrentRadioStation = bufRadioStation;
                    ViewModel.RadioContainer.Play(ViewModel.CurrentRadioStation);
                }
            }
        }
    }
}
