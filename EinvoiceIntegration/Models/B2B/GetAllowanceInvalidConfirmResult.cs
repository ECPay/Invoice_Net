using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class GetAllowanceInvalidConfirmResult
    {
        public string RtnCode { get; set; }
        public string RtnMsg { get; set; }
        public ResultDataDetail RtnData { get; set; }

        public class ResultDataDetail
        {
            public string AllowanceNo { get; set; }
            public long MerchantID { get; set; }
            public string AllowanceNumber { get; set; }
            public string SellerId { get; set; }
            public string BuyerId { get; set; }
            public string CancelDate { get; set; }
            public string CancelReason { get; set; }
            public int? Upload_Status { get; set; }
            public string Upload_Date { get; set; }
            public short ExchangeStatus { get; set; }
            public string ConfirmRemark { get; set; }
        }
    }
}
