using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    /// <summary>
    /// 折讓商品明細
    /// </summary>
    public class AllowanceItem
    {
        /// <summary>
        /// 商品金額
        /// </summary>
        [Required]
        [Display(Name = "金額")]
        [Range(-1.79769e+308, 1.79769e+308)]
        public decimal ItemAmount { get; set; }
        /// <summary>
        /// 商品數量
        /// </summary>
        [Required]
        [Display(Name = "數量")]
        [Range(0, 1.79769e+308)]
        public decimal ItemCount { get; set; }
        /// <summary>
        /// 商品名稱
        /// </summary>
        [Required]
        [Display(Name = "品名")]
        [StringLength(256)]
        public string ItemName { get; set; }
        /// <summary>
        /// 商品單價
        /// </summary>
        [Required]
        [Display(Name = "單價")]
        [Range(-1.79769e+308, 1.79769e+308)]
        public decimal ItemPrice { get; set; }
        /// <summary>
        /// 原發票日期
        /// </summary>
        public DateTime OriginalInvoiceDate { get; set; }
        /// <summary>
        /// 原發票號碼
        /// </summary>
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$")]
        public string OriginalInvoiceNumber { get; set; }
        /// <summary>
        /// 原發票號碼排序編號
        /// </summary>
        [Required]
        [Display(Name = "明細排列序號")]
        [Range(1, 999)]
        public int OriginalSequenceNumber { get; set; }
        /// <summary>
        /// 商品稅額
        /// </summary>
        [Range(-2147483648, 2147483647)]
        public int Tax { get; set; }
    }
}
