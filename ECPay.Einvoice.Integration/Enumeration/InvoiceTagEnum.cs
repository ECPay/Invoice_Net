using Ecpay.EInvoice.Integration.Attributes;

namespace Ecpay.EInvoice.Integration.Enumeration
{
    /// <summary>
    /// 發送內容類型
    /// </summary>
    public enum InvoiceTagEnum
    {
        /// <summary>
        /// 發票開立
        /// </summary>
        [Text("I")]
        Create,

        /// <summary>
        /// 發票作廢
        /// </summary>
        [Text("II")]
        Invalid,

        /// <summary>
        /// 折讓開立
        /// </summary>
        [Text("A")]
        Allowance,

        /// <summary>
        /// 折讓作廢
        /// </summary>
        [Text("AI")]
        AllowanceInvalid,

        /// <summary>
        /// 發票中獎
        /// </summary>
        [Text("W")]
        Winning
    }
}