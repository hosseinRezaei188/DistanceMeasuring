using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.IDataProvider
{
    public class IDistanceMeasureDataProvider
    {
        Task<ResponseModel.MeasureResponse> MeasureDistance();
    }
}
