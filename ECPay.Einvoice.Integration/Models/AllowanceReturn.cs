namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 開立折讓回傳Model
    /// </summary>
    public class AllowanceReturn : ReturnBase
    {
        /// <summary>
        /// 折讓單號    ‧若回應代碼 != '1'時，則VAL = ''
        /// </summary>
        public string IA_Allow_No { get; set; }

        /// <summary>
        /// 發票號碼    ‧若回應代碼 != '1'時，則VAL = ''
        /// </summary>
        public string IA_Invoice_No { get; set; }

        /// <summary>
        /// 折讓時間    ‧回傳格式為「yyyy-MM-dd HH:mm:ss」
        ///             ‧若回應代碼 = '1'時，則VAL = 折讓開立時間
        ///             ‧若回應代碼 != '1'時，則VAL = ''
        /// </summary>
        public string IA_Date { get; set; }

        /// <summary>
        /// 折讓剩餘金額      ‧若回應代碼 != '1'時，則VAL = ''
        /// </summary>
        public string IA_Remain_Allowance_Amt { get; set; }
    }
}