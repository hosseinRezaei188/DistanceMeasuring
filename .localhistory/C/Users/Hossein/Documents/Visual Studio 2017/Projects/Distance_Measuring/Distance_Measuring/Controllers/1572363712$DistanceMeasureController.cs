using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider;
        private readonly IDataProvider.IHistoryDataProvider historyDataProvider;
        private readonly IDataProvider.IUserDataProvider userDataProvider;

        public DistanceMeasureController(IMapper mapper,
            IDataProvider.IDistanceMeasureDataProvider distanceMeasureDataProvider,
            IDataProvider.IHistoryDataProvider historyDataProvider,IDataProvider.IUserDataProvider userDataProvider)
        {
            this.mapper = mapper;
            this.distanceMeasureDataProvider = distanceMeasureDataProvider;
            this.historyDataProvider = historyDataProvider;
            this.userDataProvider = userDataProvider;
        }


        [HttpPost("Measure")]
        public async Task<object> Measure(Measure measure)
        {
            #region getUserName via token
            var userName = string.Empty;
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                userName = identity.FindFirst(ClaimTypes.Name).Value;
            }

            if (!ModelState.IsValid)
            {
                return new { Error = ModelState.Errors() }; ;
            }

            dynamic result = await distanceMeasureDataProvider.
                MeasureDistance
                (
                measure.Location1, measure.Location2
                );

            if (result.Code!=StatusCodes.Status200OK)
            {
                return result;
            }
       
            await historyDataProvider.InsertHistory
                (new RequestHistory()
                {

                    Date = DateTime.Now.ToShortDateString(),
                    Locations = "{" + measure.Location1.Lat + "," + measure.Location1.Long + "} To {" +
                    measure.Location2.Lat + "," + measure.Location2.Long + "}",
                    Result = result.Distance+"",
                    User = await userDataProvider.GetUserIfExist(userName)
                });

            return result;
        }
    }

}