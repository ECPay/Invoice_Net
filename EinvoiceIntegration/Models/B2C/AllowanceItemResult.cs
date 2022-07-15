using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class AllowanceItemResult
    {
        public decimal ItemAmount { get; set; }

        public decimal ItemCount { get; set; }

        public string ItemName { get; set; }

        public decimal ItemPrice { get; set; }
        public decimal ItemRateAmt { get; set; }

        public int ItemSeq { get; set; }

        public string ItemTaxType { get; set; }

        public string ItemWord { get; set; }
    }
}
