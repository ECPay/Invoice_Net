using EinvoiceIntegration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class NotifyModel : BaseModel
    {
        /// <summary>
        /// 折讓單號
        /// </summary>
        public string AllowanceNo { get; set; }
        /// <summary>
        /// 發票日期
        /// </summary>
        [Required]
        public DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// 發票號碼
        /// </summary>
        [Required]
        [Display(Name = "發票號碼")]
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$")]
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// 發送內容類型 1: 發票開立 2: 發票作廢 3: 發票退回 
        /// 4: 折讓單開立 5:折讓單作廢 6:發票開立確認 7:發票作廢確認 
        /// 8:發票退回確認 9:折讓單開立確認 10:折讓單作廢確認
        /// </summary>
        [Required]
        [Range(1,10)]
        public byte InvoiceTag { get; set; }
        /// <summary>
        /// 發送對象 C: 發送通知給客戶 M: 發送通知給合作特店 A: 皆發送通知
        /// </summary>
        [Required]
        [Display(Name = "發送對象")]
        [RegularExpression("^[C,M,A]{1}$", ErrorMessage = "{0} 應為C、M、A")]
        public string Notified { get; set; }
        /// <summary>
        /// 通知 EMail
        /// </summary>
        [Display(Name = "通知 EMail")]
        [ValidateEmail(separator = new char[] { ';' })]
        public string NotifyMail { get; set; }
    }
}
