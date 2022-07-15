using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Models
{
    public class ApiHeaderModel
    {
        public long Timestamp { get; set; }
        public string RqID { get; set; }
        public string Revision { get; set; }
    }
}
