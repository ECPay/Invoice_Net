using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Enum.B2B
{
    public enum B2BInvoiceMethod
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
        /// 發送通知
        /// </summary>
        [Description("發送通知")]
        Notify,
        /// <summary>
        /// 折讓作廢
        /// </summary>
        [Description("折讓作廢")]
        CancelAllowance,
        /// <summary>
        /// 折讓
        /// </summary>
        [Description("折讓")]
        Allowance,
        /// <summary>
        /// 折讓接收確認
        /// </summary>
        [Description("折讓接收確認")]
        AllowanceConfirm,
        /// <summary>
        /// 退回發票
        /// </summary>
        [Description("退回發票")]
        Reject,
        /// <summary>
        /// 退回發票確認
        /// </summary>
        [Description("退回發票接收確認")]
        RejectConfirm,
        /// <summary>
        /// 折讓作廢接收確認
        /// </summary>
        [Description("折讓作廢接收確認")]
        CancelAllowanceConfirm,
        /// <summary>
        /// 取得發票確認
        /// </summary>
        [Description("取得發票確認")]
        GetIssueConfirm,
        /// <summary>
        /// 取得作廢確認
        /// </summary>
        [Description("取得作廢確認")]
        GetInvalidConfirm,
        /// <summary>
        /// 取得退回
        /// </summary>
        [Description("取得退回")]
        GetReject,
        /// <summary>
        /// 取得退回確認
        /// </summary>
        [Description("取得退回確認")]
        GetRejectConfirm,
        /// <summary>
        /// 取得折讓確認
        /// </summary>
        [Description("取得折讓確認")]
        GetAllowanceConfirm,
        /// <summary>
        /// 取得折讓作廢確認
        /// </summary>
        [Description("取得折讓作廢確認")]
        GetAllowanceInvalidConfirm,
            /// <summary>
            /// 查詢字軌
            /// </summary>
        [Description("查詢字軌")]
        GetInvoiceWordSetting,
    }
}
