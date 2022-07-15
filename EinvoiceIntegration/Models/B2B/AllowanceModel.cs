using EinvoiceIntegration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class AllowanceModel : BaseModel
    {
        /// <summary>
        /// 折讓日期
        /// </summary>
        public DateTime? AllowanceDate { get; set; }
        /// <summary>
        /// 聯絡Email
        /// </summary>
        [ValidateEmail(separator = new char[] { ';' })]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        [StringLength(100)]
        public string CustomerAddress { get; set; }

        /// <summary>
        /// 商品明細
        /// </summary>
        [Required]
        [ValidateObject]
        public List<AllowanceItem> Details { get; set; }
        /// <summary>
        /// 折讓原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 營業稅額
        /// </summary>
        public int TaxAmount { get; set; }
        /// <summary>
        /// 折讓金額總計
        /// </summary>
        [Required]
        public int TotalAmount { get; set; }
    }
}
