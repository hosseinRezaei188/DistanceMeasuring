using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distance_Measuring.Model;
using Distance_Measuring.ResponseModel;

namespace Distance_Measuring.DataProvider
{
    public class DistanceMeasureDataProvider : IDataProvider.IDistanceMeasureDataProvider
    {
        public Task<MeasureResponse> MeasureDistance
            (Location location1, Location location2)
        {
            if (IsDouble(location1.Latitude, location1.Longitude) && 
                IsDouble(location1.Latitude, location1.Longitude))
            {

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
