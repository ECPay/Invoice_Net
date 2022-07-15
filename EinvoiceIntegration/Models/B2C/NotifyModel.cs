using EinvoiceIntegration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class NotifyModel : BaseModel
    {
        /// <summary>
        /// 折讓單單號
        /// </summary>
        [Display(Name = "折讓單單號")]
        public string AllowanceNo { get; set; }
        /// <summary>
        /// 發票號碼
        /// </summary>
        [Required]
        [Display(Name = "發票號碼")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} 固定為10碼")]
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$", ErrorMessage = "{0} 格式錯誤")]
        public string InvoiceNo { get; set; }
        /// <summary>
        /// 發送內容類型 I: 發票開立 II: 發票作廢 A: 折讓開立 AI: 折讓作廢 AW:發票中獎
        /// </summary>
        [Required]
        [RegularExpression("^I$|^II$|^A$|^AI$|^AW$", ErrorMessage = "{0} 應為I、II、A、AI、AW")]
        public string InvoiceTag { get; set; }
        /// <summary>
        /// 發送對象 C: 發送通知給客戶 M: 發送通知給合作特店 A: 皆發送通知
        /// </summary>
        [Required]
        [Display(Name = "發送對象")]
        [RegularExpression("^[C,M,A]{1}$", ErrorMessage = "{0} 應為C、M、A")]
        public string Notified { get; set; }
        /// <summary>
        /// 發送方式 S:簡訊 E:電子郵件 A:皆通知時
        /// </summary>
        [Required]
        [Display(Name = "發送方式")]
        [RegularExpression("^[E,S,A]{1}$", ErrorMessage = "{0} 應為E、S、A")]
        public string Notify { get; set; }
        /// <summary>
        /// 發送電子郵件
        /// </summary>
        [Display(Name = "發送電子郵件")]
        [ValidateEmail(separator = new char[] { ';' })]
        [StringLength(80, ErrorMessage = "{0} 不得超過80碼")]
        public string NotifyMail { get; set; }
        /// <summary>
        /// 發送簡訊號碼
        /// </summary>
        [Display(Name = "發送簡訊號碼")]
        [RegularExpression("^[0-9]{1,20}$", ErrorMessage = "不正確的手機號碼格式(最多20碼)")]
        public string Phone { get; set; }
    }
}
