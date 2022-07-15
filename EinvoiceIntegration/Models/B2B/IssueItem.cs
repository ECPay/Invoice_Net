using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    /// <summary>
    /// 商品開立明細
    /// </summary>
    public class IssueItem
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
        /// 商品備註
        /// </summary>
        [Display(Name = "單一欄位備註")]
        [StringLength(40)]
        public string ItemRemark { get; set; }
        /// <summary>
        /// 商品明細排列序號
        /// </summary>
        [Required]
        [Display(Name = "明細排列序號")]
        [Range(1, 999)]
        public int ItemSeq { get; set; }
        /// <summary>
        /// 商品營業稅額
        /// </summary>
        [Display(Name = "營業稅額")]
        [Range(-2147483648, 2147483647)]
        public int? ItemTax { get; set; }
        /// <summary>
        /// 商品單位
        /// </summary>
        [Display(Name = "單位")]
        [StringLength(6)]
        public string ItemWord { get; set; }
    }
}
