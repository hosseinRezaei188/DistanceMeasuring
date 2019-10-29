using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distance_Measuring.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distance_Measuring.Controllers
{
    [Route("[controller]")]
    public class DistanceMeasureController : ControllerBase
    {
        private readonly IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider;

        public DistanceMeasureController(IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider)
        {
            this.distanceMeasureDataProvider = distanceMeasureDataProvider;
        }


        [HttpPost("Measure")]
        public Task<MeasureResponse>(Model.Location location1, Model.Location location2)
        {

        }

 
}