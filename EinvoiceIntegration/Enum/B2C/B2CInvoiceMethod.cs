using System.ComponentModel;

namespace EinvoiceIntegration.Enum.B2C
{
    public enum B2CInvoiceMethod
    {
        /// <summary>
        /// 發票開立
        /// </summary>
        [Description("發票開立")]
        Issue,
        /// <summary>
        /// 發票作廢
        /// </summary>
        [Description("發票作廢")]
        Invalid,
        /// <summary>
        /// 延遲開立發票
        /// </summary>
        [Description("延遲開立發票")]
        DelayIssue,
        /// <summary>
        /// 觸發延遲開立發票
        /// </summary>
        [Description("觸發延遲開立發票")]
        TriggerIssue,
        /// <summary>
        /// 折讓發票(紙本)
        /// </summary>
        [Description("折讓發票(紙本)")]
        Allowance,
        /// <summary>
        /// 折讓發票(線上)
        /// </summary>
        [Description("折讓發票(線上)")]
        AllowanceByCollegiate,
        /// <summary>
        /// 折讓發票作廢
        /// </summary>
        [Description("折讓發票作廢")]
        AllowanceInvalid,
        /// <summary>
        /// 發送通知
        /// </summary>
        [Description("發送通知")]
        InvoiceNotify,
        /// <summary>
        /// 查詢發票
        /// </summary>
        [Description("查詢發票")]
        GetIssue,
        /// <summary>
        /// 查詢作廢發票
        /// </summary>
        [Description("查詢作廢發票")]
        GetInvalid,
        /// <summary>
        /// 查詢折讓發票
        /// </summary>
        [Description("查詢折讓發票")]
        GetAllowance,
        /// <summary>
        /// 查詢折讓作廢發票
        /// </summary>
        [Description("查詢折讓作廢發票")]
        GetAllowanceInvalid,
        /// <summary>
        /// 檢查手機條碼
        /// </summary>
        [Description("檢查手機條碼")]
        CheckBarcode,
        /// <summary>
        /// 檢查愛心碼
        /// </summary>
        [Description("檢查愛心碼")]
        CheckLoveCode,
        /// <summary>
        /// 查詢線上折讓明細
        /// </summary>
        [Description("查詢線上折讓明細")]
        GetAllowanceByCollegiate,
        /// <summary>
        /// 註銷重開立
        /// </summary>
        [Description("註銷重開立")]
        VoidWithReIssue,
        /// <summary>
        /// 折讓取消(線上)
        /// </summary>
        [Description("折讓取消(線上)")]
        AllowanceInvalidByCollegiate,
        /// <summary>
        /// 補寄折讓合議(線上)
        /// </summary>
        [Description("補寄折讓合議(線上)")]
        InvoiceNotifyByCollegiate,
        /// <summary>
        /// 取消待開立發票
        /// </summary>
        [Description("取消待開立發票")]
        CancelDelayIssue,
        /// <summary>
        /// 查詢字軌
        /// </summary>
        [Description("查詢字軌")]
        GetInvoiceWordSetting,
    }
}
