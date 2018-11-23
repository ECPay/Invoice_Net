using System;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Attributes;
using Ecpay.EInvoice.Integration.Enumeration;
using Ecpay.EInvoice.Integration.Interface;

namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 查詢發票
    /// </summary>
    public class QueryInvoice : Iinvoice
    {
        private int _TimeStamp = Convert.ToInt32((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        private string _MerchantID = string.Empty;
        private string _RelateNumber = string.Empty;
        private string _InvoiceNumber = string.Empty;

        /// <summary>
        /// 發票類別(自動產生)
        /// </summary>
        [NonProcessValueAttribute]
        InvoiceMethodEnum Iinvoice.invM
        {
            get { return InvoiceMethodEnum.QueryInvoice; }
        }

        /// <summary>
        /// 廠商驗證時間(自動產生)
        /// </summary>
        internal int TimeStamp { get { return _TimeStamp; } private set { _TimeStamp = value; } }

        /// <summary>
        /// 廠商編號(必填)
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(10, ErrorMessage = "{0} max langth as {1}.")]
        public string MerchantID { get { return _MerchantID; } set { _MerchantID = value; } }

        /// <summary>
        /// 商家自訂訂單編號(必填) ‧預設不可重複 ‧預設最大長度為30碼
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(30, ErrorMessage = "{0} max length as {1}.")]
        public string RelateNumber { get { return _RelateNumber; } set { _RelateNumber = value; } }

        /// <summary>
        /// 發票號碼(選填)    ‧預設長度固定10碼
        /// </summary>
        [RegularExpression(@"^[A-Z]{2}[0-9]{8}$", ErrorMessage = "{0} is incorrect format.")]
        public string InvoiceNumber { get { return _InvoiceNumber; } set { _InvoiceNumber = value; } }
    }
}