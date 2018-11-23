using System;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Attributes;
using Ecpay.EInvoice.Integration.Enumeration;
using Ecpay.EInvoice.Integration.Interface;

namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    ///  EC Gateway - inv - ECBank or ECPay 付款完成觸發開立發票功能。 新版
    /// </summary>
    public class InvoiceTrigger : Iinvoice
    {
        private int _TimeStamp = Convert.ToInt32((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        private string _MerchantID = string.Empty;
        private string _Tsr = string.Empty;
        private PayTypeEnum _PayType = PayTypeEnum.ALLPAY;

        /// <summary>
        /// 發票類別(自動產生)
        /// </summary>
        [NonProcessValueAttribute]
        InvoiceMethodEnum Iinvoice.invM
        {
            get { return InvoiceMethodEnum.InvoiceTrigger; }
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
        /// 交易單號(必填)        ‧預設不可重複
        ///                       ‧預設最大長度為30碼
        /// </summary>
        [StringLength(30, ErrorMessage = "{0} max length as {1}.")]
        [Required(ErrorMessage = "{0} is required.")]
        public string Tsr { get { return _Tsr; } set { _Tsr = value; } }

        /// <summary>
        /// 交易類別(選填)            ‧固定給定下述預設值 ->若為ECBANK時，則VAL = 'ECBANK'
        ///                                                ->若為ECPAY時，則VAL = 'ECPAY'
        ///                                                ->若為ALLPAY時，則VAL = 'ALLPAY'
        ///                          ‧如無填寫或空值 ->預設值為ALLPAY
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public PayTypeEnum PayType { get { return _PayType; } set { _PayType = value; } }
    }
}