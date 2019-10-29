using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.ViewModel
{
    public class UserViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Pleasse Enter UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Pleasse Enter Password")]
        [MaxLength(ErrorMessage ="Password Must Be Minimum 3 Charracter")]
        public string Password { get; set; }

    }
}
