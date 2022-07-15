using System;
using System.ComponentModel.DataAnnotations;

namespace EinvoiceIntegration.Models.B2C
{
    public class InvalidModel : BaseModel
    {
        [Required]
        [Display(Name = "發票日期")]
        public DateTime? InvoiceDate { get; set; }

        [Display(Name = "發票號碼")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$")]
        public string InvoiceNo { get; set; }

        [Display(Name = "作廢原因")]
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Reason { get; set; }
    }
}
