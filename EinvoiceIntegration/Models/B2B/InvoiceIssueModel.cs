using EinvoiceIntegration.Attributes;
using EinvoiceIntegration.Enum;
using EinvoiceIntegration.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class InvoiceIssueModel : BaseModel
    {
        public class Item
        {
            /// <summary>
            /// 商品排列順序
            /// </summary>
            [Display(Name = "明細排列序號")]
            [Range(0, 999)]
            public int ItemSeq { get; set; }

            /// <summary>
            /// 商品名稱
            /// </summary>
            [Required]
            [Display(Name = "商品名稱")]
            [StringLength(100)]
            public string ItemName { get; set; }

            /// <summary>
            /// 商品數量
            /// </summary>
            [Required]
            [Display(Name = "商品數量")]
            [Range(0, 99999)]
            public decimal ItemCount { get; set; }

            /// <summary>
            /// 商品單位
            /// </summary>
            [Required]
            [Display(Name = "商品單位")]
            [StringLength(6)]
            public string ItemWord { get; set; }

            /// <summary>
            /// 商品價格
            /// </summary>
            [Required]
            [Display(Name = "單價")]
            [Range(-99999999, 99999999)]
            public decimal ItemPrice { get; set; }

            /// <summary>
            /// 商品合計
            /// </summary>
            [Required]
            [Display(Name = "商品合計金額")]
            [Range(-999999999999, 999999999999)]
            public decimal ItemAmount { get; set; }

            /// <summary>
            /// 商品稅額
            /// </summary>
            [Display(Name = "課稅別")]
            [RegularExpression("^[1|2|3|9]{1}$")]
            public int ItemTax { get; set; }

            /// <summary>
            /// 商品備註說明
            /// </summary>
            [Display(Name = "商品備註(單一欄位備註)")]
            [StringLength(40)]
            public string ItemRemark { get; set; }
        }

        /// <summary>
        /// 合作特店自訂編號
        /// </summary>
        public string RelateNumber { get; set; }

        /// <summary>
        /// 發票開立時間
        /// </summary>
        [Display(Name = "發票開立日期")]
        public DateTime? InvoiceTime { get; set; }

        /// <summary>
        /// 統一編號(客戶)
        /// </summary>
        [Display(Name = "統一編號(客戶)")]
        [RegularExpression("^[0]{10}$|^[0-9]{8}$", ErrorMessage = "{0} 格式錯誤")]
        public string CustomerIdentifier { get; set; }

        /// <summary>
        /// 公司地址(客戶)
        /// </summary>
        [Display(Name = "公司地址(客戶)")]
        [StringLength(100)]
        public string CustomerAddress { get; set; }

        /// <summary>
        /// 電話號碼(客戶)
        /// </summary>
        [Display(Name = "電話號碼(客戶)")]
        [StringLength(26)]
        public string CustomerTel { get; set; }

        /// <summary>
        /// EMail(客戶)
        /// </summary>
        [Display(Name = "EMail(客戶)")]
        [StringLength(80)]
        [ValidateEmail(separator = new char[] { ';' })]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 通關方式
        /// </summary>
        [Display(Name = "通關方式")]
        [RegularExpression("^[1-2]{0,1}$")]
        public string ClearanceMark
        {
            get { return clearanceMarkEnum.ToText(); }
        }

        /// <summary>
        /// 課稅類別
        /// </summary>
        [Required]
        [Display(Name = "課稅別")]
        [RegularExpression("^[1|2|3|4|9]{1}$")]
        public string TaxType
        {
            get { return taxTypeEnum.ToText(); }
        }

        /// <summary>
        /// 稅率
        /// </summary>
        public double? TaxRate { get; set; }

        /// <summary>
        /// 發票總金額(含稅)
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// 發票總金額(未稅)
        /// </summary>
        public int SalesAmount { get; set; }

        /// <summary>
        /// 營業稅額
        /// </summary>
        public int TaxAmount { get; set; }

        /// <summary>
        /// 發票備註
        /// </summary>
        public string InvoiceRemark { get; set; }

        /// <summary>
        /// 字軌類別
        ///     07:一般稅額
        ///     08:特種稅額計
        /// </summary>
        [Required]
        [Display(Name = "發票類別")]
        [RegularExpression("^0[7,8]{1}$")]
        public string InvType
        {
            get { return trackTypeEnum.ToText(); }
        }

        /// <summary>
        /// 商品明細
        /// </summary>
        public List<Item> Items { get; set; }

        private CustomsClearanceMarkEnum clearanceMarkEnum;

        [JsonIgnore]
        public CustomsClearanceMarkEnum ClearanceMarkEnum
        {
            get { return clearanceMarkEnum; }
            set { clearanceMarkEnum = value; }
        }

        private TaxTypeEnum taxTypeEnum;

        [JsonIgnore]
        public TaxTypeEnum TaxTypeEnum
        {
            get { return taxTypeEnum; }
            set { taxTypeEnum = value; }
        }

        private TrackTypeEnum trackTypeEnum;

        [JsonIgnore]
        public TrackTypeEnum TrackTypeEnum
        {
            get { return trackTypeEnum; }
            set { trackTypeEnum = value; }
        }
    }
}
