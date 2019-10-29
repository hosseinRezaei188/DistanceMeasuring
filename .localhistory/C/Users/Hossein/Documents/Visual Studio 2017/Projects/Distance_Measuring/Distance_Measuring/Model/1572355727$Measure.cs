using Geolocation;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.Model
{
    public class Measure
    {
        public int ID { get; set; }


        [Required(ErrorMessage ="Please send Location1")]
        public Location Location1 { get; set; }

        [Required(ErrorMessage = "Please send Location2")]
        public Location Location2 { get; set; }

    }

    public class Location
    {
        public int ID { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }



}
