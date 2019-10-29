using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.ResponseModel
{
    public class MeasureResponse:Response
    {
        public string Distance { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
