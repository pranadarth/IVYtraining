using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace MyGeoLocator
{
    public class Location
    {
        protected GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        protected double Range = 1000.0;

        const double RADIUS = 6378.16;//Radius of earth #Fixed value
        const double PI = 3.141592653589793;
        const double FixedLatitude = 21.146633;
        const double FixedLongitude = 79.088860;

        double ActualLatitude;
        double ActualLongitude;

        public Location()
        {
            
            watcher.Start();
            
        }

        public bool LocationCheck(double DistanceInKms = 1000.0)
        {
            Range = DistanceInKms;
            try
            {
                ActualLatitude = watcher.Position.Location.Latitude;
                ActualLongitude = watcher.Position.Location.Longitude;
                if(ActualLatitude == double.NaN)
                {
                    ActualLatitude = 0;
                    ActualLongitude = 0;
                }

            }
            catch(ArgumentOutOfRangeException ae) 
            {
                return false;
            }
            catch (Exception ex) 
            {
                ActualLatitude= 0;
                ActualLongitude= 0;
            }


            if (CalculateDistance() <= Range)
                return true;
            else
                return false;


        }


        private static double Radians(double x)
        {
            return x * PI / 180;
        }

        private double CalculateDistance()
        {
            double diffLongitude = Radians(ActualLongitude - FixedLongitude);
            double diffLatitude = Radians(ActualLatitude - FixedLatitude);

            double temp = (Math.Sin(diffLatitude / 2) * Math.Sin(diffLatitude / 2)) + Math.Cos(Radians(FixedLatitude)) * Math.Cos(Radians(ActualLatitude)) * (Math.Sin(diffLongitude / 2) * Math.Sin(diffLongitude / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(temp), Math.Sqrt(1 - temp));
            return angle * RADIUS;
        }

        ~Location()
        {
            Console.Write("ALL Over");
            
            watcher.Dispose();
        }
    }
}
