﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distance_Measuring.Model;
using Distance_Measuring.ResponseModel;
using Geolocation;

namespace Distance_Measuring.DataProvider
{
    public class DistanceMeasureDataProvider : IDataProvider.IDistanceMeasureDataProvider
    {
        public Task<MeasureResponse> MeasureDistance
            (Location location1, Location location2)
        {
            if (IsDouble(location1.Latitude, location1.Longitude) && 
                IsDouble(location2.Latitude, location2.Longitude))
            {
                double distance = GeoCalculator.
                    GetDistance(
                    double.Parse(location1.Latitude),
                    double.Parse(location1.Longitude),
                     double.Parse(location2.Latitude),
                    double.Parse(location2.Longitude),
                     1);

            }
        }

        public bool IsDouble(string Latitude, string Longitude)
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(Latitude)|| string.IsNullOrEmpty(Longitude))
            {
                return false;
            }

            isDouble = Double.TryParse(Latitude, out num)&& Double.TryParse(Longitude, out num);

            return isDouble;
        }
    }
}
