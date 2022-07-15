using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class InvalidResult : BaseResult
    {
        public string InvoiceNo { get; set; }
    }
}
