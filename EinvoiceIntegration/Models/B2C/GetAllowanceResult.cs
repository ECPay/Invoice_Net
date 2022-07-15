using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class GetAllowanceResult : BaseResult
    {
        public string IA_Allow_No { get; set; }
        public string IA_Check_Send_Mail { get; set; }
        public string IA_Date { get; set; }
        public string IA_Identifier { get; set; }
        public string IA_Invalid_Status { get; set; }
        public string IA_Invoice_Issue_Date { get; set; }
        public string IA_Invoice_No { get; set; }
        public string IA_IP { get; set; }
        public long IA_Mer_ID { get; set; }
        public string IA_Send_Mail { get; set; }
        public string IA_Send_Phone { get; set; }
        public int IA_Tax_Amount { get; set; }
        public string IA_Tax_Type { get; set; }
        public int IA_Total_Amount { get; set; }
        public int IA_Total_Tax_Amount { get; set; }
        public string IA_Upload_Date { get; set; }
        public string IA_Upload_Status { get; set; }
        public string IIS_Customer_Name { get; set; }
        public List<AllowanceItemResult> Items { get; set; }
    }
}
