using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.ViewModel
{
    public class RequestHistoryViewModel
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string Locations { get; set; }
        public string Result { get; set; }
    }
}
