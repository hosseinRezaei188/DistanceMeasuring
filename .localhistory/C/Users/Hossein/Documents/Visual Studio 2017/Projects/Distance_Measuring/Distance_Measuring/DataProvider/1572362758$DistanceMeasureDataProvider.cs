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
            if (IsDouble(location1.Lat, location1.Long) &&
                IsDouble(location2.Lat, location2.Long))
            {
                double distance = GeoCalculator.
                    GetDistance(
                    double.Parse(location1.Lat),
                    double.Parse(location1.Long),
                    double.Parse(location2.Lat),
                    double.Parse(location2.Long), 1);
                measureResponse = new MeasureResponse()
                {
                    Location1 = location1,
                    Location2 = location2,
                    Distance = distance + " mile",
                    Code = StatusCodes.Status200OK,
                    Message = "Ok"

                };

                return measureResponse;
            }

            return new Response()
            {
                Code = StatusCodes.Status500InternalServerError,
                Message = "Input Location Coordinates is Incorrect"
            };
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
