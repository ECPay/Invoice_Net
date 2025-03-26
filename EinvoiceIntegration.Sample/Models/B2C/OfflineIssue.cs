using EinvoiceIntegration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EinvoiceIntegration.Sample.Models.B2C
{
    public class OfflineIssue
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
            /// 商品稅額
            /// 1：應稅
            /// 2：零稅率
            /// 3：免稅
            /// </summary>
            public string ItemTaxType { get; set; }

            /// <summary>
            /// 商品合計(含稅金額)
            /// </summary>
            public decimal ItemAmount { get; set; }

            /// <summary>
            /// 商品備註說明
            /// </summary>
            public string ItemRemark { get; set; }
        }

        /// <summary>
        /// 廠商編號
        /// </summary>
        public long MerchantID { get; set; }

        /// <summary>
        /// 機器編號
        /// </summary>
        public string MachineID { get; set; }

        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 發票開立日期 (yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// 自訂編號
        /// </summary>
        public string RelateNumber { get; set; }

        /// <summary>
        /// 課稅類別
        /// </summary>
        public TaxTypeEnum TaxType { get; set; }

        /// <summary>
        /// 發票總金額(含稅)
        /// </summary>
        public int SalesAmount { get; set; }

        /// <summary>
        /// 字軌類別
        /// </summary>
        public TrackTypeEnum InvType { get; set; }

        /// <summary>
        /// 隨機碼
        /// </summary>
        public string RandomNumber { get; set; }

        /// <summary>
        /// 商品明細
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// 統一編號(客戶)
        /// </summary>
        public string CustomerIdentifier { get; set; }

        /// <summary>
        /// 客戶編號
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 客戶地址
        /// </summary>
        public string CustomerAddr { get; set; }

        /// <summary>
        /// 客戶手機號碼
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// 客戶電子信箱
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 通關方式
        /// </summary>
        public CustomsClearanceMarkEnum ClearanceMark { get; set; }

        /// <summary>
        /// 特種稅額類別
        /// </summary>
        public SpecialTaxTypeEnum SpecialTaxType { get; set; }

        /// <summary>
        /// 商品單價是否含稅
        /// </summary>
        public VatEnum Vat { get; set; }

        /// <summary>
        /// 發票備註
        /// </summary>
        public string InvoiceRemark { get; set; }

        /// <summary>
        /// 客戶名稱
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 列印註記
        /// </summary>
        public PrintEnum Print { get; set; }

        /// <summary>
        /// 捐贈註記
        /// </summary>
        public DonationEnum Donation { get; set; }

        /// <summary>
        /// 捐贈碼
        /// </summary>
        public string LoveCode { get; set; }

        /// <summary>
        /// 載具類別
        /// </summary>
        public CarrierTypeEnum CarrierType { get; set; }

        /// <summary>
        /// 載具編號
        /// </summary>
        public string CarrierNum { get; set; }

        /// <summary>
        /// 零稅率原因
        /// </summary>
        public ZeroTaxRateReasonEnum ZeroTaxRateReason { get; set; }
    }
}