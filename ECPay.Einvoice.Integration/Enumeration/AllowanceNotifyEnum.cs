using Ecpay.EInvoice.Integration.Attributes;

namespace Ecpay.EInvoice.Integration.Enumeration
{
    public enum AllowanceNotifyEnum
    {
        /// <summary>
        /// 簡訊通知
        /// </summary>
        [Text("S")]
        SMS,

        /// <summary>
        /// E-mail通知
        /// </summary>
        [Text("E")]
        Email,

        /// <summary>
        /// 皆通知
        /// </summary>
        [Text("A")]
        All,

        /// <summary>
        /// 皆不通知
        /// </summary>
        [Text("E")]
        None
    }
}