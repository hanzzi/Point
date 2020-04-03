using System;
using System.ComponentModel;

namespace Point.Models
{
    public class PointEntry : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public bool IsMock { get; set; }

        private double? _latitude = null;
        public double? Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Latitude"));
            }
        }
        private double? _longitude = null;
        public double? Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Longitude"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}