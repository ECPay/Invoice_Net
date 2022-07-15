using System;

namespace EinvoiceIntegration.Sample.Models.B2B
{
    public class InvoiceInvalid
    {
        /// <summary>
        /// 廠商編號
        /// </summary>
        public long MerchantID { get; set; }

        /// <summary>
        /// 開立日期
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// 作廢原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
    }
}