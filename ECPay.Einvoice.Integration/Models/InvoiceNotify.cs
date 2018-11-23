using System;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Attributes;
using Ecpay.EInvoice.Integration.Enumeration;
using Ecpay.EInvoice.Integration.Interface;
using Ecpay.EInvoice.Integration.Service;

namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 發送發票開立/折讓/作廢/中獎 通知信 & SMS
    /// </summary>
    public class InvoiceNotify : Iinvoice
    {
        private int _TimeStamp = Convert.ToInt32((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        private string _MerchantID = string.Empty;
        private string _InvoiceNo = string.Empty;
        private string _AllowanceNo = string.Empty;
        private string _Phone = string.Empty;
        private string _NotifyMail = string.Empty;
        private InvoiceNotifyEnum _Notify = InvoiceNotifyEnum.Email;        //預設為E-mail通知
        private InvoiceTagEnum _InvoiceTag;                                 //無預設值
        private NotifiedObjectEnum _Notified;                               //無預設值

        /// <summary>
        /// 發票類別(自動產生)
        /// </summary>
        [NonProcessValueAttribute]
        InvoiceMethodEnum Iinvoice.invM
        {
            get { return InvoiceMethodEnum.Notify; }
        }

        /// <summary>
        /// 廠商編號(必填)
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(10, ErrorMessage = "{0} max langth as {1}.")]
        public string MerchantID { get { return _MerchantID; } set { _MerchantID = value; } }

        /// <summary>
        /// 廠商驗證時間(自動產生)。
        /// </summary>
        internal int TimeStamp { get { return _TimeStamp; } private set { _TimeStamp = value; } }

        /// <summary>
        /// 發票號碼(必填)    ‧預設長度固定10碼
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [RegularExpression(@"^[A-Z]{2}[0-9]{8}$", ErrorMessage = "{0} is incorrect format.")]
        public string InvoiceNo { get { return _InvoiceNo; } set { _InvoiceNo = value; } }

        /// <summary>
        /// 折讓單號(選填)    ‧預設長度固定16碼
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]{16}$", ErrorMessage = "{0} is incorrect format.")]
        public string AllowanceNo { get { return _AllowanceNo; } set { _AllowanceNo = value; } }

        /// <summary>
        ///發送簡訊號碼(選填)   ‧若客戶手機號碼有值時，則 ->預設格式為數字組成
        ///                                                ->預設最小長度為1碼，最大長度為20碼
        ///                     ‧補充說明(下述情況通知手機號碼不可為空值) ->通知電子信箱為空值
        ///                                                                ->通知類別為-簡訊
        /// </summary>
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "{0} is incorrect format.")]
        [StringLength(20, ErrorMessage = "{0} max length as {1}.")]
        [RequiredByNotifyPhoneOrEmail(ErrorMessage = "Phone number and e-mail in which a required.")]
        public string Phone { get { return _Phone; } set { _Phone = value; } }

        /// <summary>
        /// 發送email(選填)     ‧若客戶電子信箱有值時，則 ->格式僅能為Email的標準格式
        ///                     ‧補充說明(下述情況通知電子信箱不可為空值) ->通知手機號碼為空值
        ///                                                                ->通知類別為-電子郵件
        /// </summary>
        [StringLength(80, ErrorMessage = "{0} max length as {1}.")]
        [RegularExpression(@"^[^\s]+@[^\s]+\.[^\s]+$", ErrorMessage = "{0} is incorrect format.")]
        [NeedEncode]
        [RequiredByNotifyPhoneOrEmail(ErrorMessage = "Phone number and e-mail in which a required.")]
        public string NotifyMail { get { return _NotifyMail; } set { _NotifyMail = value; } }

        /// <summary>
        /// 發送方式(選填)    ‧固定給定下述預設值 ->若為簡訊時，則VAL = 'SMS'
        ///                                        ->若為電子郵件時，則VAL = 'Email'
        ///                                        ->若為皆通知時，則VAL = 'All'
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [NonProcessValue]
        public InvoiceNotifyEnum notify { get { return _Notify; } set { _Notify = value; } }

        internal string Notify { get { return _Notify.ToText(); } }

        /// <summary>
        /// 發送內容類型(必填)  ‧固定給定下述預設值 ->若為發票開立時，則VAL = 'I'
        ///                                          ->若為發票作廢時，則VAL = 'II'
        ///                                          ->若為折讓開立時，則VAL = 'A'
        ///                                          ->若為折讓作廢時，則VAL = 'AI'
        ///                                          ->若為發票中獎時，則VAL = 'AW'
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [NonProcessValue]
        public InvoiceTagEnum invoiceTag { get { return _InvoiceTag; } set { _InvoiceTag = value; } }

        internal string InvoiceTag { get { return _InvoiceTag.ToText(); } }

        /// <summary>
        /// 發送對象(必填)    ‧固定給定下述預設值 ->若為發送通知給客戶時，則VAL ='Customer'
        ///                                        ->若為發送通知給廠商時，則VAL = 'Merchant'
        ///                                        ->若為皆發送通知時，則VAL = 'All'
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [NonProcessValue]
        public NotifiedObjectEnum notified { get { return _Notified; } set { _Notified = value; } }

        internal string Notified { get { return _Notified.ToText(); } }
    }
}