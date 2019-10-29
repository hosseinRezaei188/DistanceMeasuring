using Distance_Measuring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.ResponseModel
{
    public class MeasureResponse:Response
    {
        public string Distance { get; set; }
        public Location Latitude { get; set; }
        public Location Longitude { get; set; }
    }
}
