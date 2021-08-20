using DeliveryService.API.Entities;
using System;

namespace DeliveryService.API.BusinessLogic
{
    public static class DistanceCalculation
    {
        public static double Calculate(City from, City to)
        {   
            //FROM City parameters
            double firstLatitude = from.Latitude;
            double firstLongitude = from.Longitude;

            //TO City parameters
            double secondLatitude = to.Latitude;
            double secondLongitude = to.Longitude;

            /*
                Formula Haversine in kilometers
                https://superuser.com/questions/602798/how-to-do-a-great-circle-calculation-in-ms-excel-or-libreoffice
                https://stackoverflow.com/questions/837872/calculate-distance-in-meters-when-you-know-longitude-and-latitude-in-java
            */

            double R = 6371; // meters => 6431e3
            double lat1 = firstLatitude * Math.PI / 180;
            double lat2 = secondLatitude * Math.PI / 180;
            double dLat = (secondLatitude - firstLatitude) * Math.PI / 180;
            double dLon = (secondLongitude - firstLongitude) * Math.PI / 180;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                      Math.Cos(lat1) * Math.Cos(lat2) *
                      Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // kilometres
            double d = R * c; 

            // returns distance in kilometers
            return d;
        }
    }
}
