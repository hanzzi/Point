using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Point.Models;
using Xamarin.Essentials;

namespace Point.Utilities
{
    class LocationUtil
    {
        public static async Task<Coordinate> GetCurrentLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, new TimeSpan(0,0,3));
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                // COORDINATE FOUND
                Coordinate coordinate = new Coordinate(location.Latitude, location.Longitude, location.Altitude);
                return coordinate;
            }
            else
            {
                // NO LOCATION FOUND
                Coordinate coordinate = new Coordinate(0, 0, 0);
                return coordinate;
            }
        }

        public static async Task<bool> IsMockProvider()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null && location.IsFromMockProvider)
                return true;
            else
                return false;
        }
    }
}
