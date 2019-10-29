﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distance_Measuring.ClassHelper;
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
        public async Task<object> Register(UserViewModel user)
        {
            object result;
           
            //check user model rules
            if (!ModelState.IsValid)
            {
                //get user model error via helper class and return
                return new { Error = ModelState.Errors() }; ;
            }
            result = await userDataProvider.Register(user);
            return result;

        }


        [HttpPost("Login")]
        public async Task<object> Login(UserViewModel user)
        {
            object result;
            if (!ModelState.IsValid)
            {
                //get user model error via helper class and return
                return new { Error = ModelState.Errors() }; ;
            }

            //return user info
            result = await userDataProvider.Login(user);

            return result;

        }

        
    }
}