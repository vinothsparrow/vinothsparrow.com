using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.Windows.Controls.Primitives;

namespace MapLocationChooser.Tasks
{
    public partial class LocationPickerPart : UserControl
    {
        private bool _isReturn;
        public LocationPickerPart()
        {
            InitializeComponent();
            ShowMyLocationOnTheMap();
        }

        public async void ShowMyLocationOnTheMap()
        {
            var geolocator = new Geolocator();
            Geoposition position = await geolocator.GetGeopositionAsync();
            Geocoordinate coordinate = position.Coordinate;
            this.mapControl.Center = new System.Device.Location.GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            this.mapControl.ZoomLevel = 13;
        }

        public System.Device.Location.GeoCoordinate GetLocation()
        {
            return _isReturn ? this.mapControl.Center : null;
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            _isReturn = true;
            (this.Parent as Popup).IsOpen = false;
        }

        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            _isReturn = true;
            (this.Parent as Popup).IsOpen = false;
        }
    }
}
