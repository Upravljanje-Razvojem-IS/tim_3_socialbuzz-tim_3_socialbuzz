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

            // metres
            double R = 6371e3; 
            double φ1 = firstLatitude * Math.PI / 180;
            double φ2 = secondLatitude * Math.PI / 180;
            double Δφ = (secondLatitude - firstLatitude) * Math.PI / 180;
            double Δλ = (secondLongitude - firstLongitude) * Math.PI / 180;

            double a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                      Math.Cos(φ1) * Math.Cos(φ2) *
                      Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // metres
            double d = R * c; 

            return d/1000;
        }
    }
}
