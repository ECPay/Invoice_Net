using System;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Attributes;
using Ecpay.EInvoice.Integration.Enumeration;
using Ecpay.EInvoice.Integration.Interface;
using Ecpay.EInvoice.Integration.Service;

namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 開立發票
    /// </summary>
    public class InvoiceCreate : Iinvoice
    {
        private string _MerchantID = string.Empty;
        private int _TimeStamp = Convert.ToInt32((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        private string _RelateNumber = string.Empty;
        private string _CustomerID = string.Empty;
        private string _CustomerIdentifier = string.Empty;
        private string _CustomerName = string.Empty;
        private string _CustomerAddr = string.Empty;
        private string _CustomerPhone = string.Empty;
        private string _CustomerEmail = string.Empty;
        private CustomsClearanceMarkEnum _ClearanceMark = CustomsClearanceMarkEnum.None;
        private PrintEnum _Print = PrintEnum.No;
        private DonationEnum _Donation = DonationEnum.No;
        private string _LoveCode = string.Empty;
        private CarruerTypeEnum _CarruerType = CarruerTypeEnum.None;
        private string _CarruerNum = string.Empty;
        private TaxTypeEnum _TaxType = TaxTypeEnum.Taxable;
        private decimal _SalesAmount;
        private string _InvoiceRemark = string.Empty;
        private TheWordTypeEnum _InvType = TheWordTypeEnum.Normal;
        private VatEnum _vat = VatEnum.Yes;
        private string _InvCreateDate = string.Empty;
        private ItemCollection _Items;
        private string _AllPayMid = string.Empty;

        public InvoiceCreate()
        {
            this.Items = new ItemCollection();
        }

        /// <summary>
        /// 發票類別(自動產生)
        /// </summary>
        [NonProcessValueAttribute]
        InvoiceMethodEnum Iinvoice.invM
        {
            get { return InvoiceMethodEnum.InvoiceCreate; }
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

        public void SetTimeStamp(DateTime dateTime)
        {
            _TimeStamp = Convert.ToInt32((dateTime.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        }


        /// <summary>
        /// 商家自訂訂單編號(必填) ‧預設不可重複 ‧預設最大長度為30碼
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(30, ErrorMessage = "{0} max length as {1}.")]
        public string RelateNumber { get { return _RelateNumber; } set { _RelateNumber = value; } }

        /// <summary>
        /// 客戶代號(選填)    ‧若載具類別 = 'Member' (會員載具)時，則客戶代號須有值
        ///                   ‧若客戶代號有值時，則 ->預設最大長度為20碼
        ///                                          ->只接受英、數字與下底線格式
        /// </summary>
        [StringLength(20, ErrorMessage = "{0} max length as {1}.")]
        [RegularExpression(@"^[0-9a-zA-Z_]+$", ErrorMessage = "{0} is incorrect format.")]
        [RequiredByCarruerType(ErrorMessage = "If CarruerType equal to Member , then {0} is required.")]
        public string CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }

        /// <summary>
        /// 統一編號(選填)    ‧若統一編號有值時，則固定長度為數字8碼
        /// </summary>
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "{0} is incorrect format.")]
        [RequiredByDonation(ErrorMessage = "If {0} is not empty,then Donation is No.")]
        [RequiredByCarruerType(ErrorMessage = @"If {0} is not empty,then CarruerType not in('Member','NaturalPersonEvidence') ")]
        [RequiredByPrintFlag(ErrorMessage = "If {0} is not empty,then Print must be Yes.")]
        public string CustomerIdentifier { get { return _CustomerIdentifier; } set { _CustomerIdentifier = value; } }

        /// <summary>
        /// 客戶名稱(選填)    ‧若列印註記 = 'Yes' (列印)時，則客戶名稱須有值
        ///                   ‧若客戶名稱有值時，則 ->僅能為中英數字格式
        ///                                          ->預設最大長度為30碼
        /// </summary>
        [StringLength(60, ErrorMessage = "{0} max length as {1}.")]
        [RequiredByPrintFlag(ErrorMessage = "If PrintFlag equal to Yes , then {0} is required.")]
        [NeedEncode]
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }

        /// <summary>
        /// 客戶地址(選填)    ‧若列印註記 = 'Yes' (列印)時，則客戶地址須有值 ->預設最大長度為100碼
        /// </summary>
        [StringLength(100, ErrorMessage = "{0} max length as {1}.")]
        [RequiredByPrintFlag(ErrorMessage = "If PrintFlag equal to Yes , then {0} is required.")]
        [NeedEncode]
        public string CustomerAddr { get { return _CustomerAddr; } set { _CustomerAddr = value; } }

        /// <summary>
        /// 客戶手機號碼(選填) ‧若客戶電子信箱為空值時，則客戶手機號碼不可為空值
        ///                    ‧若客戶手機號碼有值時，則 ->預設格式為數字組成
        ///                                               ->預設最小長度為1碼，最大長度為20碼
        /// </summary>
        [RequiredByPhoneOrEmail(ErrorMessage = "Phone number and e-mail in which a required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "{0} is incorrect format.")]
        [StringLength(20, ErrorMessage = "{0} max length as {1}.")]
        public string CustomerPhone { get { return _CustomerPhone; } set { _CustomerPhone = value; } }

        /// <summary>
        /// 客戶電子信箱(選填)  ‧若客戶手機號碼為空值時，則客戶電子信箱不可為空值
        ///                     ‧若客戶電子信箱有值時，則 ->格式僅能為Email的標準格式
        ///                                                ->預設最大長度為80碼
        /// </summary>
        [StringLength(80, ErrorMessage = "{0} max length as {1}.")]
        [RegularExpression(@"^[^\s]+@[^\s]+\.[^\s]+$", ErrorMessage = "{0} is incorrect format.")]
        [RequiredByPhoneOrEmail(ErrorMessage = "Phone number and e-mail in which a required.")]
        [NeedEncode]
        public string CustomerEmail { get { return _CustomerEmail; } set { _CustomerEmail = value; } }

        /// <summary>
        /// 通關方式(選填)    ‧若課稅類別 = ZeroTaxRate(零稅率)時 ->則VAL = 'Yes'(經海關出口)或'No'(非經海關出口)
        ///                   ‧若課稅類別 != ZeroTaxRate(零稅率)時 ->則VAL = 'None'
        ///                   ‧如無填寫或空值 ->預設值為None
        /// </summary>
        [RequiredByTaxType(ErrorMessage = @"If TaxType equal to ZeroTaxRate , then {0} is 'Yes' or 'No' ,else {0} is None.")]
        public CustomsClearanceMarkEnum ClearanceMark { get { return _ClearanceMark; } set { _ClearanceMark = value; } }

        /// <summary>
        /// 列印註記(選填)    ‧若列印註記有值時，則 ->僅能為VAL = 'No' (不列印)或VAL = 'Yes' (列印)
        ///                   ‧補充說明 ->若捐贈註記 = 'Yes' (捐贈)時，則VAL = 'No' (不列印)
        ///                              ->若統一編號有值時，則VAL = 'Yes' (列印)
        ///                   ‧如無填寫或空值 ->預設值為不列印
        /// </summary>
        [RequiredByPrintFlag(ErrorMessage = "If CustomerIdentifier is not empty,then {0} is Yes.")]
        [RequiredByDonation(ErrorMessage = "If Donation equal to 1,then {0} is No.")]
        [Required(ErrorMessage = "{0} is required.")]
        public PrintEnum Print { get { return _Print; } set { _Print = value; } }

        /// <summary>
        /// 捐贈註記(選填)    ‧固定給定下述預設值 ->若為捐贈時，則VAL = 'Yes'
        ///                                        ->若為不捐贈時，則VAL = 'No'
        ///                   ‧補充說明 ->若統一編號有值時，則VAL = 'No' (不捐贈)
        ///                   ‧如無填寫或空值 ->預設值為不捐贈
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public DonationEnum Donation { get { return _Donation; } set { _Donation = value; } }

        /// <summary>
        /// 愛心碼(選填)     ‧若捐贈註記 = 'Yes' (捐贈)時，則 ->須有值
        ///                                                    ->長度限制為3至7碼
        ///                                                    ->格式為全數字或1碼大小寫「X」加上2至6碼數字
        /// </summary>
        [RequiredByDonation(ErrorMessage = "If Donation equal to Yes,then {0} is required.")]
        [RegularExpression(@"^([Xx0-9])[0-9]{2,6}$", ErrorMessage = "{0} is incorrect format.")]
        public string LoveCode { get { return _LoveCode; } set { _LoveCode = value; } }

        /// <summary>
        /// 載具類別(選填)    ‧固定給定下述預設值 ->若為無載具時，則VAL = 'None'
        ///                                        ->若為會員載具時，則VAL = 'Member'
        ///                                        ->若為買受人之自然人憑證號碼時，則VAL = 'NaturalPersonEvidence'
        ///                                        ->若為買受人之手機條碼資料時，則VAL = 'PhoneBarcode'
        ///                   ‧補充說明 ->若統一編號有值時，則載具類別不可為會員載具或自然人憑證載具
        ///                   ‧如無填寫或空值 ->預設值為無載具類別
        /// </summary>
        [NonProcessValue]
        public CarruerTypeEnum carruerType { set { _CarruerType = value; } get { return _CarruerType; } }

        internal string CarruerType { get { return _CarruerType.ToText(); } }

        /// <summary>
        /// 載具編號(選填)    ‧若載具類別為無載具或會員載具時，則VAL=''
        ///                   ‧若載具類別為買受人之自然人憑證號碼時，則 ->須有值
        ///                                                              ->長度固定16碼
        ///                                                              ->格式為2碼大小寫字母加上14碼數字
        ///                   ‧若載具類別為買受人之手機條碼資料時，則 ->須有值
        ///                                                            ->長度固定7碼
        ///                                                            ->格式為1碼斜線「/」加上由7碼加號、減號、句號、數字及大小寫字母組成
        /// </summary>
        [RequiredByCarruerTypeNumFormat(ErrorMessage = @"{0} is incorrect format.")]
        public string CarruerNum { get { return _CarruerNum; } set { _CarruerNum = value; } }

        /// <summary>
        /// 課稅類別(選填)    ‧固定給定下述預設值  ->若為應稅時，則VAL = 'Taxable'
        ///                                         ->若為零稅率時，則VAL = 'ZeroTaxRate'
        ///                                         ->若為免稅時，則VAL = 'DutyFree'
        ///                                         ->若為混合應稅與免稅時(限收銀機發票無法分辨時使用，且需通過申請核可)，則VAL = 'MixedTaxable'
        ///                   ‧如無填寫或空值 ->預設值為Taxable(應稅)
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public TaxTypeEnum TaxType { get { return _TaxType; } set { _TaxType = value; } }

        /// <summary>
        /// 發票金額(必填)    ‧含稅總金額
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [StringFormat("F0")]
        public decimal SalesAmount { get { return _SalesAmount; } set { _SalesAmount = value; } }

        /// <summary>
        /// 備註(選填)
        /// </summary>
        [NeedEncode]
        public string InvoiceRemark { get { return _InvoiceRemark; } set { _InvoiceRemark = value; } }

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
        /// 發票字軌類別(選填)  ‧固定給定下述預設值 ->若為一般稅額計算時，則VAL = 'Normal'
        ///                                          ->若為特種稅額計算時，則VAL = 'Special'
        ///                     ‧如無填寫或空值 ->預設值為Normal(一般稅額)
        /// </summary>
        [NonProcessValue]
        public TheWordTypeEnum invType { get { return _InvType; } set { _InvType = value; } }

        internal string InvType { get { return _InvType.ToText(); } }

        /// <summary>
        /// 發票開立時間(選填)    ‧預設格式如下 「yyyy-MM-dd HH:mm:ss」
        ///                       ‧不得大於當下時間且限48小時以內的時間
        ///                       ‧如無填寫或空值 ->發票開立時間預設值為當下時間
        /// </summary>
        [NeedEncode]
        public string InvCreateDate { get { return _InvCreateDate; } set { _InvCreateDate = (string.IsNullOrEmpty(value) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : value); } }

        /// <summary>
        /// 商品單價是否含稅(選填)      ‧固定給定下述預設值 ->若為含稅價，則VAL = 'Yes'
        ///                                                  ->若為未稅價時，則VAL = 'No'
        ///                             ‧如無填寫或空值 ->預設值為Yes (含稅價)
        /// </summary>
        public VatEnum vat { get { return _vat; } set { _vat = value; } }

        ///// <summary>
        ///// 會員->買家Mid (選填) 文件上沒有, 暫不使用
        ///// </summary>
        //public string EcpayMid { get { return _AllPayMid; } set { _AllPayMid = value; } }

        /// <summary>
        /// 商品資訊的集合別(必填)
        /// </summary>
        [NeedDetailValid]
        public ItemCollection Items { get { return _Items; } set { _Items = value; } }
    }
}