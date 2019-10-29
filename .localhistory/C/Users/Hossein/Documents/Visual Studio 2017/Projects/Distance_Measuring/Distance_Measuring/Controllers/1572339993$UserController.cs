using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distance_Measuring.IDataProvider;
using Distance_Measuring.Model;
using Distance_Measuring.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distance_Measuring.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserDataProvider userDataProvider;

        public UserController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }


        [HttpPost("Register")]
        public Task<object> Register(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);

            
            }
            return userDataProvider.Register(user);

        }
    }
}