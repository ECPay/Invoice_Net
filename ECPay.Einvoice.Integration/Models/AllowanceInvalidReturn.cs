namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 折讓作廢回傳Model
    /// </summary>
    public class AllowanceInvalidReturn : ReturnBase
    {
        /// <summary>
        /// 發票號碼    ‧若回應代碼 = '1'時，則VAL = 發票號碼
        ///             ‧若回應代碼 != '1'時，則VAL = ''
        /// </summary>
        public string IA_Invoice_No { get; set; }
    }
}