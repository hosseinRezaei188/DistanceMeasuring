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
            if (IsDouble(location1.Latitude) && IsDouble(location1.Longitude) && IsDouble(location2.Latitude) && IsDouble(location2.Longitude))
            {

            }
        }

        public bool IsDouble(string location1)
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(location1))
            {
                return false;
            }

            isDouble = Double.TryParse(location1, out num);

            return isDouble;
        }
    }
}
