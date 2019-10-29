using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distance_Measuring.Model;
using Distance_Measuring.ResponseModel;
using Geolocation;
using Microsoft.AspNetCore.Http;

namespace Distance_Measuring.DataProvider
{
    public class DistanceMeasureDataProvider : 
        IDataProvider.IDistanceMeasureDataProvider
    {
        public async Task<Response> MeasureDistance
            (Location location1, Location location2)
        {
            Response measureResponse;
            if (IsDouble(location1.Latitude, location1.Longitude) &&
                IsDouble(location2.Latitude, location2.Longitude))
            {
                double distance = GeoCalculator.
                    GetDistance(
                    double.Parse(location1.Latitude),
                    double.Parse(location1.Longitude),
                    double.Parse(location2.Latitude),
                    double.Parse(location2.Longitude),1);
                measureResponse = new MeasureResponse()
                {
                    Location1 = location1,
                    Location2 = location2,
                    Distance = distance,
                    Code = StatusCodes.Status200OK,
                    Message="Ok"

                };

                return measureResponse;
            }
            return new Response() {Code=StatusCodes.Status500InternalServerError,
            Message="Input Location Coordinates is Incorrect"};
        }

        public bool IsDouble(string Latitude, string Longitude)
        {
            double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(Latitude) || string.IsNullOrEmpty(Longitude))
            {
                return false;
            }

            isDouble = double.TryParse(Latitude, out num) && double.TryParse(Longitude, out num);

            return isDouble;
        }
    }
}
