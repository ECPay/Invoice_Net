namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 發送通知回傳Model
    /// </summary>
    public class InvoiceNotifyReturn : ReturnBase
    {
        /// <summary>
        /// 廠商代號
        /// </summary>
        public string MerchantID { get; set; }
    }
}