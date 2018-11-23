using Ecpay.EInvoice.Integration.Attributes;

namespace Ecpay.EInvoice.Integration.Enumeration
{
    /// <summary>
    /// 發送對象
    /// </summary>
    public enum NotifiedObjectEnum
    {
        /// <summary>
        /// 發送通知對象為客戶
        /// </summary>
        [Text("C")]
        Customer,

        /// <summary>
        /// 發送通知對象為廠商
        /// </summary>
        [Text("M")]
        Merchant,

        /// <summary>
        /// 皆發送通知
        /// </summary>
        [Text("A")]
        All
    }
}