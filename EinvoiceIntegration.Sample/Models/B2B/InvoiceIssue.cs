using EinvoiceIntegration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EinvoiceIntegration.Sample.Models.B2B
{
    public class InvoiceIssue
    {
        public class Item
        {
            /// <summary>
            /// 商品排列順序
            /// </summary>
            public int ItemSeq { get; set; }

            /// <summary>
            /// 商品名稱
            /// </summary>
            public string ItemName { get; set; }

            /// <summary>
            /// 商品數量
            /// </summary>
            public decimal ItemCount { get; set; }

            /// <summary>
            /// 商品單位
            /// </summary>
            public string ItemWord { get; set; }

            /// <summary>
            /// 商品價格
            /// </summary>
            public decimal ItemPrice { get; set; }

            /// <summary>
            /// 商品合計
            /// </summary>
            public decimal ItemAmount { get; set; }

            /// <summary>
            /// 商品稅額
            /// </summary>
            public int ItemTax { get; set; }

            /// <summary>
            /// 商品備註說明
            /// </summary>
            public string ItemRemark { get; set; }
        }

        /// <summary>
        /// 合作特店編號
        /// </summary>
        public long MerchantID { get; set; }

        /// <summary>
        /// 合作特店自訂編號
        /// </summary>
        public string RelateNumber { get; set; }

        /// <summary>
        /// 發票開立時間
        /// </summary>
        public DateTime? InvoiceTime { get; set; }

        /// <summary>
        /// 統一編號(客戶)
        /// </summary>
        public string CustomerIdentifier { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string CustomerAddress { get; set; }

        /// <summary>
        /// 電話號碼
        /// </summary>
        public string CustomerTel { get; set; }

        /// <summary>
        /// EMail(客戶)
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 通關方式
        /// </summary>
        public CustomsClearanceMarkEnum ClearanceMark { get; set; }

        /// <summary>
        /// 課稅類別
        /// </summary>
        public TaxTypeEnum TaxType { get; set; }

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
        /// </summary>
        public TrackTypeEnum InvType { get; set; }

        /// <summary>
        /// 商品明細
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// 特種稅率類別
        /// </summary>
        public SpecialTaxTypeEnum SpecialTaxType { get; set; }

        /// <summary>
        /// 零稅率原因
        /// </summary>
        public ZeroTaxRateReasonEnum ZeroTaxRateReason { get; set; }
    }
}