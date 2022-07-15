using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class InvoiceInvalidResult : BaseResult
    {
        public ResultDataDetail RtnData { get; set; }
        public class ResultDataDetail
        {
            public long MerchantID { get; set; }
            public string InvoiceNumber { get; set; }
            public string SellerId { get; set; }
            public string BuyerId { get; set; }
            public string CancelDate { get; set; }
            public string CancelTime { get; set; }
            public string CancelReason { get; set; }
            public int? Upload_Status { get; set; }
            public string Upload_Date { get; set; }
            public string ConfirmDate { get; set; }
            public byte? ExchangeStatus { get; set; }
            public string Remark { get; set; }
        }
    }
}
