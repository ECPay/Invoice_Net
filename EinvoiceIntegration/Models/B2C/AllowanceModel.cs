using EinvoiceIntegration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class AllowanceModel :BaseModel
    {
        /// <summary>
        /// 折讓單總金額(含稅)
        /// </summary>
        [Required]
        [Display(Name = "折讓單總金額(含稅)")]
        [Range(1, 2147483647)]
        public int AllowanceAmount { get; set; }
        /// <summary>
        /// 通知類別 S:簡訊 E:電子郵件 A:皆通知時 N:皆不通知
        /// </summary>
        [Required]
        [Display(Name = "通知類別")]
        [RegularExpression("^[S|E|A|N|]{1}$")]
        public string AllowanceNotify { get; set; }
        /// <summary>
        /// 客戶名稱
        /// </summary>
        [Display(Name = "客戶名稱")]
        [StringLength(60)]
        //[RegularExpression("^[A-Za-z0-9一-龥豈-鶴]+$", ErrorMessage = "客戶名稱格式錯誤。")]
        public string CustomerName { get; set; }
        /// <summary>
        /// 發票日期
        /// </summary>
        [Required]
        [Display(Name = "發票日期")]
        public DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// 發票號碼
        /// </summary>
        [Required]
        [Display(Name = "發票號碼")]
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$")]
        public string InvoiceNo { get; set; }
        /// <summary>
        /// 商品明細
        /// </summary>
        [Required]
        [Display(Name = "商品明細")]
        [ValidateObject]
        public List<InvoiceIssueModel.Item> Items { get; set; }
        /// <summary>
        /// 通知電子信箱
        /// </summary>
        [Display(Name = "通知電子信箱")]
        [ValidateEmail(separator = new char[] { ';' })]
        public string NotifyMail { get; set; }
        /// <summary>
        /// 通知手機號碼
        /// </summary>
        [Display(Name = "通知手機號碼")]
        [RegularExpression("^[0-9]{1,200}$")]
        public string NotifyPhone { get; set; }
        /// <summary>
        /// 折讓原因
        /// </summary>
        [Display(Name = "折讓原因")]
        [StringLength(50)]
        public string Reason { get; set; }
    }
}
