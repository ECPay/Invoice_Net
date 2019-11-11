using System.ComponentModel;

namespace Ecpay.EInvoice.Integration.Enumeration
{
    /// <summary>
    /// 發票方法
    /// </summary>
    public enum InvoiceMethodEnum
    {
        [Description("發票開立")]
        InvoiceCreate,

        [Description("發票作廢")]
        InvoiceInvalid,

        [Description("延遲開立發票")]
        InvoiceDelay,

        [Description("觸發延遲開立發票")]
        InvoiceTrigger,

        [Description("折讓發票(紙本)")]
        Allowance,

        [Description("折讓發票(線上)")]
        AllowanceByCollegiate,

        [Description("折讓發票作廢")]
        AllowanceInvalid,

        [Description("發送通知")]
        Notify,

        [Description("查詢發票")]
        QueryInvoice,

        [Description("查詢作廢發票")]
        QueryInvoiceInvalid,

        [Description("查詢折讓發票")]
        QueryAllowance,

        [Description("查詢折讓作廢發票")]
        QueryAllowanceInvalid,

        [Description("檢查手機條碼")]
        CheckMobileBarCode,

        [Description("檢查愛心碼")]
        CheckLoveCode,
    }
}