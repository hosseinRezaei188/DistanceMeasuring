using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distance_Measuring.Controllers
{
    [Route("[controller]")]
    public class DistanceMeasureController : ControllerBase
    {
        private readonly IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider;

        public DistanceMeasureController
            (IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider)
        {
            this.distanceMeasureDataProvider = distanceMeasureDataProvider;
        }


        [HttpPost("Measure")]


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