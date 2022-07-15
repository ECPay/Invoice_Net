using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class GetIssueResult : BaseResult
    {
        public string IIS_Award_Flag { get; set; }
        public int IIS_Award_Type { get; set; }
        public string IIS_Carrier_Num { get; set; }
        public string IIS_Carrier_Type { get; set; }
        public string IIS_Category { get; set; }
        public string IIS_Check_Number { get; set; }
        public string IIS_Clearance_Mark { get; set; }
        public string IIS_Create_Date { get; set; }
        public string IIS_Customer_Addr { get; set; }
        public string IIS_Customer_Email { get; set; }
        public string IIS_Customer_ID { get; set; }
        public string IIS_Customer_Name { get; set; }
        public string IIS_Customer_Phone { get; set; }
        public string IIS_Identifier { get; set; }
        public string IIS_Invalid_Status { get; set; }
        public string IIS_IP { get; set; }
        public string IIS_Issue_Status { get; set; }
        public string IIS_Love_Code { get; set; }
        public long IIS_Mer_ID { get; set; }
        public string IIS_Number { get; set; }
        public string IIS_Print_Flag { get; set; }
        public string IIS_Random_Number { get; set; }
        public string IIS_Relate_Number { get; set; }
        public int IIS_Remain_Allowance_Amt { get; set; }
        public int IIS_Sales_Amount { get; set; }
        public int IIS_Tax_Amount { get; set; }
        public decimal IIS_Tax_Rate { get; set; }
        public string IIS_Tax_Type { get; set; }
        public string IIS_Turnkey_Status { get; set; }
        public string IIS_Type { get; set; }
        public string IIS_Upload_Date { get; set; }
        public string IIS_Upload_Status { get; set; }
        public string InvoiceRemark { get; set; }
        public List<InvoiceIssueModel.Item> Items { get; set; }
        public string PosBarCode { get; set; }
        public string QRCode_Left { get; set; }
        public string QRCode_Right { get; set; }
        /// <summary>
        /// 特種稅率類別
        /// </summary>
        public byte SpecialTaxType { get; set; }
    }
}
