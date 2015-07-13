using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MapLocationChooser.Resources;
using MapLocationChooser.Tasks;

namespace MapLocationChooser
{
    public partial class MainPage : PhoneApplicationPage
    {
        private LocationPickerTask _locationPicker;

        public MainPage()
        {
            InitializeComponent();
            _locationPicker = new LocationPickerTask();
            _locationPicker.Completed += locationPicker_Completed;
        }

        void locationPicker_Completed(object sender, LocationPickerTaskResult e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                MessageBox.Show("Lat:" + e.GeoCoordinate.Latitude + ",Lon:" + e.GeoCoordinate.Longitude);
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _locationPicker.Show();
        }
    }
}