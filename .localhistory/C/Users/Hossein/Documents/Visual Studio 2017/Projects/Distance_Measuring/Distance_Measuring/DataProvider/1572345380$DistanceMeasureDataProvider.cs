﻿using System;
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
    }
}
