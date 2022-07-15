using System;
using System.ComponentModel.DataAnnotations;

namespace EinvoiceIntegration.Sample.Models.B2C
{
    public class InvoiceInvalid
    {
        /// <summary>
        /// 特店編號
        /// </summary>
        public long MerchantID { get; set; }

        /// <summary>
        /// 發票日期
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 作廢原因
        /// </summary>
        public string Reason { get; set; }
    }
}