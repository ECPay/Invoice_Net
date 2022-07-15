using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class InvoiceIssueResult : BaseResult
    {
        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 開立日期
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RandomNumber { get; set; }
    }
}
