using EinvoiceIntegration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class InvoiceNotifyByCollegiateModel : BaseModel
    {
        [Required]
        [Display(Name = "折讓單單號")]
        public string AllowanceNo { get; set; }
        [Required]
        [Display(Name = "發票號碼")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} 固定為10碼")]
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$", ErrorMessage = "{0} 格式錯誤")]
        public string InvoiceNo { get; set; }
        [Required]
        [Display(Name = "發送電子郵件")]
        [ValidateEmail(ErrorMessage = "不正確的Email格式")]
        [StringLength(80, ErrorMessage = "{0} 不得超過80碼")]
        public string NotifyMail { get; set; }
    }
}
