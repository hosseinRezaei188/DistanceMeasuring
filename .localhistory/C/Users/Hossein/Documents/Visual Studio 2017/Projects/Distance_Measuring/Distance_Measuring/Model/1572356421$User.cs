using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.Model
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; }

    }
}
