using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace MapLocationChooser.Tasks
{
    public class LocationPickerTaskResult : TaskEventArgs
    {
        public LocationPickerTaskResult()
        {

        }

        public LocationPickerTaskResult(GeoCoordinate geoCoordinate)
        {
            GeoCoordinate = geoCoordinate;
            IsCancelled = false;
        }

        public GeoCoordinate GeoCoordinate { get; private set; }
        public bool IsCancelled { get; private set; }
    }

    public class LocationPickerTask : ChooserBase<LocationPickerTaskResult>
    {
        private readonly Popup _popUp;
        private LocationPickerPart _child;
        public bool IsOpen { get; set; }

        public LocationPickerTask()
        {
            _popUp = new Popup();
            var height = Application.Current.Host.Content.ActualHeight;
            var width = Application.Current.Host.Content.ActualWidth;
            _child = new LocationPickerPart() { Height = height, Width = width };

            _popUp.Height = height;
            _popUp.Width = width;
            _popUp.Child = _child;
            _popUp.Closed += popUp_Closed;
        }

        public override void Show()
        {
            _child.ShowMyLocationOnTheMap();
            _popUp.IsOpen = true;
            IsOpen = true;
        }

        void popUp_Closed(object sender, EventArgs e)
        {
            var location = _child.GetLocation();
            if (location != null)
                FireCompleted(this, new LocationPickerTaskResult(location), null);
            else
                FireCompleted(this, new LocationPickerTaskResult(), null);
        }
    }
}
