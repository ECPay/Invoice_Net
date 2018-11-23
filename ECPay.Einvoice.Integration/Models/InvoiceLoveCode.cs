using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Attributes;
using Ecpay.EInvoice.Integration.Enumeration;
using Ecpay.EInvoice.Integration.Interface;

namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 愛心碼驗證
    /// </summary>
    public class InvoiceLoveCode : Iinvoice
    {
        private int _TimeStamp = Convert.ToInt32((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        private string _MerchantID = string.Empty;
        private string _LoveCode = string.Empty;
        /// <summary>
        /// 發票類別(自動產生)
        /// </summary>
        [NonProcessValueAttribute]
        InvoiceMethodEnum Iinvoice.invM
        {
            get { return InvoiceMethodEnum.CheckLoveCode; }
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
        /// 發票號碼(選填)    ‧預設長度固定10碼
        /// </summary>
        [StringLength(7, ErrorMessage = "{0} max langth as {1}.")]
        public string LoveCode { get { return _LoveCode; } set { _LoveCode = value; } }
    }
}
