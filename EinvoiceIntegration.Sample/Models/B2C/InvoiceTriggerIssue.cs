using EinvoiceIntegration.Enum;

namespace EinvoiceIntegration.Sample.Models.B2C
{
    public class InvoiceTriggerIssue
    {
        /// <summary>
        /// 廠商編號
        /// </summary>
        public long MerchantID { get; set; }

        /// <summary>
        /// 交易單號
        /// </summary>
        public string Tsr { get; set; }

        /// <summary>
        /// 交易類別
        /// </summary>
        public PayTypeEnum PayType { get; set; }
    }
}