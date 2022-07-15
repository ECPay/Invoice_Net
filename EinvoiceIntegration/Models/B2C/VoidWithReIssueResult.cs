using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class VoidWithReIssueResult : BaseResult
    {
        public string InvoiceNo { get; set; }

        public string InvoiceDate { get; set; }

        public string RandomNumber { get; set; }
    }
}
