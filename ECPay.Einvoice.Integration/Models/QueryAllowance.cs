using System;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Attributes;
using Ecpay.EInvoice.Integration.Enumeration;
using Ecpay.EInvoice.Integration.Interface;

namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 折讓單單筆明細
    /// </summary>
    public class QueryAllowance : Iinvoice
    {
        private int _TimeStamp = Convert.ToInt32((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        private string _MerchantID = string.Empty;
        private string _InvoiceNo = string.Empty;
        private string _AllowanceNo = string.Empty;

        /// <summary>
        /// 發票類別(自動產生)
        /// </summary>
        [NonProcessValueAttribute]
        InvoiceMethodEnum Iinvoice.invM
        {
            get { return InvoiceMethodEnum.QueryAllowance; }
        }

        /// <summary>
        /// 廠商編號(必填)
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(10, ErrorMessage = "{0} max langth as {1}.")]
        public string MerchantID { get; set; }

        /// <summary>
        /// 廠商驗證時間(自動產生)
        /// </summary>
        internal int TimeStamp { get { return _TimeStamp; } private set { _TimeStamp = value; } }

        /// <summary>
        /// 發票號碼(必填)    ‧預設長度固定10碼
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [RegularExpression(@"^[A-Z]{2}[0-9]{8}$", ErrorMessage = "{0} is incorrect format.")]
        public string InvoiceNo { get { return _InvoiceNo; } set { _InvoiceNo = value; } }

        /// <summary>
        /// 折讓單號(必填)    ‧預設長度固定16碼
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [RegularExpression(@"^[a-zA-Z0-9]{16}$", ErrorMessage = "{0} is incorrect format.")]
        public string AllowanceNo { get { return _AllowanceNo; } set { _AllowanceNo = value; } }
    }
}