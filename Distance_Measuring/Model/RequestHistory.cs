using Distance_Measuring.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.Model
{
    public class RequestHistory
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string Locations { get; set; }
        public string Result { get; set; }
        public User User { get; set; }
    }
}
