namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 發票作廢回傳Model
    /// </summary>
    public class InvoiceInvalidReturn : ReturnBase
    {
        /// <summary>
        /// 發票號碼    ‧若回應代碼 = '1'時，則VAL = 發票號碼
        ///             ‧若回應代碼 != '1'時，則VAL = ''
        /// </summary>
        public string InvoiceNumber { get; set; }
    }
}