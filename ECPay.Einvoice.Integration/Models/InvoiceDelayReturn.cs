namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 延遲或觸發開立發票 回傳Model
    /// </summary>
    public class InvoiceDelayReturn : ReturnBase
    {
        /// <summary>
        /// 交易單號    ‧若回應代碼 = '1'時，則VAL = 交易單號(Tsr)
        ///             ‧若回應代碼 != '1'時，則VAL = ''
        /// </summary>
        public string OrderNumber { get; set; }
    }
}