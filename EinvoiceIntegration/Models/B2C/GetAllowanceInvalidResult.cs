using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class GetAllowanceInvalidResult : BaseResult
    {
        public string AI_Allow_Date { get; set; }
        public string AI_Allow_No { get; set; }
        public string AI_Buyer_Identifier { get; set; }
        public string AI_Date { get; set; }
        public string AI_Invoice_No { get; set; }
        public long AI_Mer_ID { get; set; }
        public string AI_Seller_Identifier { get; set; }
        public string AI_Upload_Date { get; set; }
        public string AI_Upload_Status { get; set; }
        public string Reason { get; set; }
    }
}
