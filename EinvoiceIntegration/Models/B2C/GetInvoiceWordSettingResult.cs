using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class GetInvoiceWordSettingResult : BaseResult
    {
        public class InvoiceInfoItem
        {
            /// <summary>
            /// 字軌號碼ID
            /// </summary>
            public string TrackID { get; set; }

            /// <summary>
            /// 發票年度
            /// </summary>
            public string InvoiceYear { get; set; }

            /// <summary>
            /// 發票期別
            /// </summary>
            public int InvoiceTerm { get; set; }

            /// <summary>
            /// 發票類別
            /// </summary>
            public int InvoiceCategory { get; set; }

            /// <summary>
            /// 字軌類別
            /// </summary>
            public string InvType { get; set; }

            /// <summary>
            /// 字軌名稱
            /// </summary>
            public string InvoiceHeader { get; set; }

            /// <summary>
            /// 起始發票編號
            /// </summary>
            public string InvoiceStart { get; set; }

            /// <summary>
            /// 結束發票編號
            /// </summary>
            public string InvoiceEnd { get; set; }

            /// <summary>
            /// 目前已使用號碼
            /// </summary>
            public string InvoiceNo { get; set; }

            /// <summary>
            /// 使用狀態
            /// </summary>
            public int UseStatus { get; set; }
        }

        public List<InvoiceInfoItem> InvoiceInfo { get; set; }

    }
}
