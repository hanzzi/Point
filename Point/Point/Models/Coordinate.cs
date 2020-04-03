using System;
using System.Collections.Generic;
using System.Text;

namespace Point.Models
{
    public class Coordinate
    {
        public double Latitude;
        public double Longitude;
        public double? Altitude;

        public Coordinate(double lat, double lng, double? alt)
        {
            Latitude = lat;
            Longitude = lng;
            Altitude = alt;
        }
    }
}
