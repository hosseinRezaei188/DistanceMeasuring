using Distance_Measuring.Model;
using Distance_Measuring.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.IDataProvider
{
    public interface IDistanceMeasureDataProvider
    {
        Task<Response> MeasureDistance(Geolocation.Coordinate location1, Geolocation.Coordinate location2);

    }
}
