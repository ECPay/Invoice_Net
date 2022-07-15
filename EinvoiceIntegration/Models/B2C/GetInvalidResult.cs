using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class GetInvalidResult : BaseResult
    {
        public string II_Buyer_Identifier { get; set; }
        public string II_Date { get; set; }
        public string II_Invoice_No { get; set; }
        public string II_Seller_Identifier { get; set; }
        public string II_Upload_Date { get; set; }
        public string II_Upload_Status { get; set; }
        public long IIS_Mer_ID { get; set; }
        public string Reason { get; set; }
    }
}
