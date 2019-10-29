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
            if (location1.Latitude)
            {

            }
        }

        public bool IsDouble(string text)
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDouble = Double.TryParse(text, out num);

            return isDouble;
        }
    }
}
