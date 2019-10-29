using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Distance_Measuring.ClassHelper;
using Distance_Measuring.Model;
using Distance_Measuring.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distance_Measuring.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]

    public class DistanceMeasureController : ControllerBase
    {
        private readonly IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider;
        private readonly IDataProvider.IHistoryDataProvider historyDataProvider;

        public DistanceMeasureController(
            IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider,
            IDataProvider.IHistoryDataProvider historyDataProvider)
        {
            this.distanceMeasureDataProvider = distanceMeasureDataProvider;
            this.historyDataProvider = historyDataProvider;
        }


        [HttpPost("Measure")]
        public async Task<object> Measure(Measure measure)
        {
            var email = string.Empty;
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                email = identity.FindFirst(ClaimTypes.Name).Value;
            }

            object result;
            if (!ModelState.IsValid)
            {
                return new { Error = ModelState.Errors() }; ;
            }
            result = await distanceMeasureDataProvider.
                MeasureDistance(measure.Location1, measure.Location2);

            await historyDataProvider.InsertHistory
                (new RequestHistory()
                {

                    Date = DateTime.Now.ToShortDateString(),
                    Locations = "{" +
                    measure.Location1.Lat + "," + measure.Location1.Long + "}{" +
                    " To " + measure.Location2.Lat + "," + measure.Location2.Long + "}",

                    Result = result.ToString(),
                    User = new User()
                });

            return result;
        }
    }

}