namespace Ecpay.EInvoice.Integration.Models
{
    public abstract class ReturnBase
    {
        /// <summary>
        /// 回應代碼
        /// </summary>
        public string RtnCode { get; set; }

        /// <summary>
        /// 回應代碼說明
        /// </summary>
        public string RtnMsg { get; set; }
    }
}