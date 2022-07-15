using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class GetRejectConfirmResult
    {
        public string RtnCode { get; set; }
        public string RtnMsg { get; set; }
        public ResultDataDetail RtnData { get; set; }
        public class ResultDataDetail
        {
            public long MerchantID { get; set; }
            public string InvoiceNumber { get; set; }
            public string SellerId { get; set; }
            public string BuyerId { get; set; }
            public string RejectDate { get; set; }
            public string RejectTime { get; set; }
            public int? Upload_Status { get; set; }
            public string Upload_Date { get; set; }
            public string ConfirmDate { get; set; }
            public string ConfirmRemark { get; set; }
        }
    }
}
