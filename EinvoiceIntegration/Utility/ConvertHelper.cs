using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Utility
{
    public class ConvertHelper
    {
        private static DateTime dtTimespanBase = new DateTime(1970, 1, 1).AddHours(8);
        public static long Date2Timespan(DateTime d)
        {
            return (long)d.Subtract(dtTimespanBase).TotalMilliseconds;
        }
    }
}
