using System;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Attributes;
using Ecpay.EInvoice.Integration.Enumeration;
using Ecpay.EInvoice.Integration.Interface;
using Ecpay.EInvoice.Integration.Service;

namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 開立折讓
    /// </summary>
    public class Allowance : Iinvoice
    {
        private int _TimeStamp = Convert.ToInt32((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        private string _MerchantID = string.Empty;
        private string _InvoiceNo = string.Empty;
        private AllowanceNotifyEnum _AllowanceNotify = AllowanceNotifyEnum.Email;
        private string _CustomerName = string.Empty;
        private string _NotifyMail = string.Empty;
        private string _NotifyPhone = string.Empty;
        private string _AllowanceAmount = string.Empty;
        private ItemCollection _Items;

        public Allowance()
        {
            this.Items = new ItemCollection();
        }

        /// <summary>
        /// 發票類別(自動產生)
        /// </summary>
        [NonProcessValueAttribute]
        InvoiceMethodEnum Iinvoice.invM
        {
            get { return InvoiceMethodEnum.Allowance; }
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
        /// 發票號碼(必填)        ‧預設長度固定10碼
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [RegularExpression(@"^[A-Z]{2}[0-9]{8}$", ErrorMessage = "{0} is incorrect format.")]
        public string InvoiceNo { get { return _InvoiceNo; } set { _InvoiceNo = value; } }

        /// <summary>
        /// 通知類別(必填)        ‧固定給定下述預設值 ->若為簡訊時，則VAL = 'SMS'
        ///                                            ->若為電子郵件時，則VAL = 'Email'
        ///                                            ->若為皆通知時，則VAL = 'All'
        ///                                            ->若為皆不通知時，則VAL = 'None'
        ///                       ‧如無填寫或空值     ->預設值為Email(電子郵件)
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [NonProcessValue]
        public AllowanceNotifyEnum allowanceNotify { set { _AllowanceNotify = value; } get { return _AllowanceNotify; } }

        [Required(ErrorMessage = "{0} is required.")]
        internal string AllowanceNotify { get { return _AllowanceNotify.ToText(); } }

        /// <summary>
        /// 客戶名稱(選填)    ‧若客戶名稱有值時，則 ->僅能為中英數字格式
        ///                                          ->預設最大長度為30碼
        /// </summary>
        [StringLength(30, ErrorMessage = "{0} max length as {1}.")]
        [RegularExpression(@"^[0-9a-zA-Z\u0391-\uFFE5]+$", ErrorMessage = "{0} is incorrect format.")]
        [NeedEncode]
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }

        /// <summary>
        /// 客戶手機號碼(選填) ‧若客戶手機號碼有值時，則 ->預設格式為數字組成
        ///                                               ->預設最小長度為1碼，最大長度為20碼
        ///                    ‧補充說明(下述情況通知手機號碼不可為空值) ->通知電子信箱為空值
        ///                                                               ->通知類別為-簡訊
        /// </summary>
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "{0} is incorrect format.")]
        [StringLength(20, ErrorMessage = "{0} max length as {1}.")]
        [RequiredByAllowanceNotify(ErrorMessage = "Phone number and e-mail in which a required,or select a incorrect notify type.")]
        public string NotifyPhone { get { return _NotifyPhone; } set { _NotifyPhone = value; } }

        /// <summary>
        /// 客戶電子信箱(選填)  ‧若客戶電子信箱有值時，則 ->格式僅能為Email的標準格式
        ///                     ‧補充說明(下述情況通知電子信箱不可為空值) ->通知手機號碼為空值
        ///                                                                ->通知類別為-電子郵件
        /// </summary>
        [StringLength(80, ErrorMessage = "{0} max length as {1}.")]
        [RegularExpression(@"^[^\s]+@[^\s]+\.[^\s]+$", ErrorMessage = "{0} is incorrect format.")]
        [RequiredByAllowanceNotify(ErrorMessage = "Phone number and e-mail in which a required,or select a incorrect notify type.")]
        [NeedEncode]
        public string NotifyMail { get { return _NotifyMail; } set { _NotifyMail = value; } }

        /// <summary>
        /// 折讓單總金額(必填)    ‧含稅總金額
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "{0} is incorrect format.")]
        public string AllowanceAmount { get { return _AllowanceAmount; } set { _AllowanceAmount = value; } }

        /// <summary>
        /// 商品名稱(自動產生)    ‧預設格式如下 名稱1 | 名稱2 | 名稱3 | … | 名稱n
        ///                       ‧若含二筆或以上的商品名稱時，則以「|」符號區隔
        /// </summary>
        [NeedEncode]
        internal string ItemName { get { return _Items.ItemName; } }

        /// <summary>
        /// 商品數量(自動產生)    ‧預設格式如下 數量1 | 數量2 | 數量3 | … | 數量n
        ///                       ‧若含二筆或以上的商品數量時，則以「|」符號區隔
        /// </summary>
        internal string ItemCount { get { return _Items.ItemCount; } }

        /// <summary>
        /// 商品單位(自動產生)    ‧預設格式如下 單位1 | 單位2 | 單位3 | … | 單位n
        ///                       ‧若含二筆或以上的商品單位時，則以「|」符號區隔
        ///                       ‧預設最大長度為6碼
        /// </summary>
        [NeedEncode]
        internal string ItemWord { get { return _Items.ItemWord; } }

        /// <summary>
        /// 商品價格(自動產生)    ‧預設格式如下 價格1 | 價格2 | 價格3 | … | 價格n
        ///                       ‧若含二筆或以上的商品價格時，則以「|」符號區隔
        ///                       ‧含稅單價金額
        /// </summary>
        internal string ItemPrice { get { return _Items.ItemPrice; } }

        /// <summary>
        /// 商品課稅別(自動產生)  ‧預設格式如下 課稅類別1 |課稅類別2 |課稅類別3 | … |課稅類別n
        ///                       ‧若含二筆或以上的商品課稅別時，則以「|」符號區隔
        ///                       ‧課稅類別需混合應稅與免稅，TaxType = 9時
        ///                       ‧商品課稅別固定給定下述預設值 ->若為應稅時，則VAL = '1' ->若為免稅時，則VAL = '3'
        ///                       ‧需含二筆或以上的商品課稅別，且至少需有一筆商品課稅別為應稅及至少需有一筆商品課稅別為免稅
        /// </summary>
        internal string ItemTaxType { get { return _Items.ItemTaxType; } }

        /// <summary>
        /// 商品合計(自動產生)    ‧預設格式如下 合計1 | 合計2 | 合計3 | … | 合計n
        ///                       ‧若含二筆或以上的商品合計時，則以「|」符號區隔
        ///                       ‧含稅小計金額
        /// </summary>
        internal string ItemAmount { get { return _Items.ItemAmount; } }

        /// <summary>
        /// 商品資訊的集合類別(必填)
        /// </summary>
        public ItemCollection Items { get { return _Items; } set { _Items = value; } }
    }
}