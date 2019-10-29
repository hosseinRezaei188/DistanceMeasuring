using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.ResponseModel
{
    public class UserResponse:Response
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
