using System;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Attributes;
using Ecpay.EInvoice.Integration.Enumeration;
using Ecpay.EInvoice.Integration.Interface;

namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 折讓作廢
    /// </summary>
    public class AllowanceInvalid : Iinvoice
    {
        private int _TimeStamp = Convert.ToInt32((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        private string _MerchantID = string.Empty;
        private string _InvoiceNo = string.Empty;
        private string _AllowanceNo = string.Empty;
        private string _Reason = string.Empty;

        /// <summary>
        /// 發票類別(自動產生)
        /// </summary>
        [NonProcessValueAttribute]
        InvoiceMethodEnum Iinvoice.invM
        {
            get { return InvoiceMethodEnum.AllowanceInvalid; }
        }

        /// <summary>
        /// 廠商編號(必填)
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(10, ErrorMessage = "{0} max langth as {1}.")]
        public string MerchantID { get { return _MerchantID; } set { _MerchantID = value; } }

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

        /// <summary>
        /// 作廢原因        ‧字數限制在20(含)個字以內
        /// </summary>
        [StringLength(20, ErrorMessage = "{0} max length as {1}.")]
        [Required(ErrorMessage = "{0} is required.")]
        [NeedEncode]
        public string Reason { get { return _Reason; } set { _Reason = value; } }
    }
}