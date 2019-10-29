using Distance_Measuring.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.Model
{
    public class RequestHistory
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public MeasureViewModel Mesure { get; set; }
        public string Result { get; set; }
        public User User { get; set; }
    }
}
