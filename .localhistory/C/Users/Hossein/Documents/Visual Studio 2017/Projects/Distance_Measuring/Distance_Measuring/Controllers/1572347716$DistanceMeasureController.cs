﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distance_Measuring.ClassHelper;
using Distance_Measuring.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distance_Measuring.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DistanceMeasureController : ControllerBase
    {
        private readonly IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider;

        public DistanceMeasureController(IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider)
        {
            this.distanceMeasureDataProvider = distanceMeasureDataProvider;
        }


        [HttpPost("Measure")]
        public async Task<object> Measure
            ([FromBody]Model.Location location1,[FromBody] Model.Location location2)
        {
            object result;
            if (!ModelState.IsValid)
            {
                return new { Error = ModelState.Errors() }; ;
            }
            result = await distanceMeasureDataProvider.MeasureDistance(location1, location2);
            return result; 
        }
    }

}