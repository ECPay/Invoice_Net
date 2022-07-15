using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class GetAllowanceResult : BaseResult
    {
        public ResultDataDetail RtnData { get; set; }

        public class ResultDataDetail
        {
            public long MerchantID { get; set; }
            public string AllowanceNo { get; set; }
            public string AllowanceNumber { get; set; }
            public string AllowanceType { get; set; }
            public string Seller_Identifier { get; set; }
            public string Seller_Name { get; set; }
            public string Buyer_Identifier { get; set; }
            public string Buyer_Name { get; set; }
            public string Buyer_Address { get; set; }
            public string Buyer_TelephoneNumber { get; set; }
            public string Buyer_EmailAddress { get; set; }
            public int TaxAmount { get; set; }
            public int TotalAmount { get; set; }
            public long? IP { get; set; }
            public string AllowanceDate { get; set; }
            public int? Upload_Status { get; set; }
            public string Upload_Date { get; set; }
            public string ConfirmDate { get; set; }
            public byte Invalid_Status { get; set; }
            public short ExchangeStatus { get; set; }
            public List<QueryAllowanceItem> items { get; set; }
        }
        public class QueryAllowanceItem
        {
            public int BalanceAmount { get; set; }
            public string InvoiceType { get; set; }
            public string TaxType { get; set; }
            public DateTime OriginalInvoiceDate { get; set; }
            public string OriginalInvoiceNumber { get; set; }
            public int OriginalSequenceNumber { get; set; }
            public string OriginalDescription { get; set; }
            public int AllowanceSequenceNumber { get; set; }
            public decimal Quantity { get; set; }
            public string Unit { get; set; }
            public decimal UnitPrice { get; set; }
            public int Tax { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
