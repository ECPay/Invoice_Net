using EinvoiceIntegration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EinvoiceIntegration.Sample.Models.B2C
{
    public class InvoiceIssue
    {
        public class Item
        {
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
            /// 商品單價
            /// </summary>
            public decimal ItemPrice { get; set; }

            /// <summary>
            /// 課稅別
            /// </summary>
            public int ItemTaxType { get; set; }

            /// <summary>
            /// 商品合計金額
            /// </summary>
            public decimal ItemAmount { get; set; }

            /// <summary>
            /// 商品備註
            /// </summary>
            public string ItemRemark { get; set; }
        }

        /// <summary>
        /// 廠商編號
        /// </summary>
        public long MerchantID { get; set; }

        /// <summary>
        /// 自訂編號
        /// </summary>
        public string RelateNumber { get; set; }

        /// <summary>
        /// 客戶編號
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 客戶統一編號
        /// </summary>
        public string CustomerIdentifier { get; set; }

        /// <summary>
        /// 客戶名稱
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 客戶地址
        /// </summary>
        public string CustomerAddr { get; set; }

        /// <summary>
        /// 客戶手機號碼
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// 客戶Email
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 通關方式
        /// </summary>
        public CustomsClearanceMarkEnum ClearanceMark { get; set; }

        /// <summary>
        /// 是否列印
        /// </summary>
        public PrintEnum Print { get; set; }

        /// <summary>
        /// 是否捐贈
        /// </summary>
        public DonationEnum Donation { get; set; }

        /// <summary>
        /// 捐贈碼
        /// </summary>
        public string LoveCode { get; set; }

        /// <summary>
        /// 載具類型
        /// </summary>
        public CarrierTypeEnum CarrierType { get; set; }

        /// <summary>
        /// 載具號碼
        /// </summary>
        public string CarrierNum { get; set; }

        /// <summary>
        /// 課稅類型
        /// </summary>
        public TaxTypeEnum TaxType { get; set; }

        /// <summary>
        /// 應稅銷售額合計
        /// </summary>
        public int SalesAmount { get; set; }

        /// <summary>
        /// 發票備註
        /// </summary>
        public string InvoiceRemark { get; set; }

        /// <summary>
        /// 字軌類型
        /// </summary>
        public TrackTypeEnum InvType { get; set; }

        /// <summary>
        /// 是否含稅
        /// </summary>
        public VatEnum Vat { get; set; }

        /// <summary>
        /// 發票開立日期
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// 商品明細
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// 特種稅率類別
        /// </summary>
        public SpecialTaxTypeEnum SpecialTaxType { get; set; }

        /// <summary>
        /// 通路商編號
        /// </summary>
        public ChannelPartnerEnum ChannelPartner { get; set; }

        /// <summary>
        /// 產品服務別代號
        /// </summary>
        public string ProductServiceID { get; set; }

        /// <summary>
        /// 零稅率原因
        /// </summary>
        public ZeroTaxRateReasonEnum ZeroTaxRateReason { get; set; }
    }
}