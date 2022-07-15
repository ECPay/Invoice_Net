using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class GetIssueResult : BaseResult
    {
        public ResultDataDetail RtnData { get; set; }
        public class ResultDataDetail
        {
            public long MerchantID { get; set; }
            public string InvoiceNumber { get; set; }
            public string InvoiceDate { get; set; }
            public string RelateNumber { get; set; }
            public string Buyer_Identifier { get; set; }
            public string Buyer_Name { get; set; }
            public string Buyer_Address { get; set; }
            public string Buyer_TelephoneNumber { get; set; }
            public string Buyer_EmailAddress { get; set; }
            public string Buyer_FacsimileNumber { get; set; }
            public string CustomsClearanceMark { get; set; }
            public string InvoiceType { get; set; }
            public string TaxType { get; set; }
            public double TaxRate { get; set; }
            public int SalesAmount { get; set; }
            public int TaxAmount { get; set; }
            public int TotalAmount { get; set; }
            public long? IP { get; set; }
            public string CreateDate { get; set; }
            public byte Issue_Status { get; set; }
            public int? Upload_Status { get; set; }
            public string Upload_Date { get; set; }
            public string ConfirmDate { get; set; }
            public byte Invalid_Status { get; set; }
            public byte ExchangeMode { get; set; }
            public short ExchangeStatus { get; set; }
            public int BalanceAmount { get; set; }
            public string MainRemark { get; set; }
            public List<IssueItem> items { get; set; }
        }
    }
}
