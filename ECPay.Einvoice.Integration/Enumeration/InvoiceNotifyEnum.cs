using Ecpay.EInvoice.Integration.Attributes;

namespace Ecpay.EInvoice.Integration.Enumeration
{
    /// <summary>
    /// 發送方式
    /// </summary>
    public enum InvoiceNotifyEnum
    {
        /// <summary>
        /// 電子郵件通知
        /// </summary>
        [Text("E")]
        Email,

        /// <summary>
        /// 簡訊通知
        /// </summary>
        [Text("S")]
        SMS,

        /// <summary>
        /// 皆通知
        /// </summary>
        [Text("A")]
        ALL,
    }
}