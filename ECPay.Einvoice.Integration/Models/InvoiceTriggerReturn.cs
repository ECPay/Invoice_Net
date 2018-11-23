namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 付款完成觸發或延遲開立發票回傳Model
    /// </summary>
    public class InvoiceTriggerReturn : ReturnBase
    {
        /// <summary>
        /// 交易單號
        /// </summary>
        public string Tsr { get; set; }
    }
}