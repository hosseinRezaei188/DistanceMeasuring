﻿using Geolocation;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.Model
{
    public class Measure
    {
        public Location Location1 { get; set; }
        public Location Location2 { get; set; }

    }

    public class Location
    {
        public string Lat { get; set; }
        public string Long { get; set; }
    }



}
