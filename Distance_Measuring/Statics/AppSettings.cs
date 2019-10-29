using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.Statics
{
    public class AppSettings
    {
        #region #TokenSecret

        public string Secret { get; set; }
        #endregion

        #region #ConnectionString

        public static string CONNECTION_STRING = @"server=.;database=DistanceMeasuring;Trusted_Connection=True;";

        #endregion
    }
}
