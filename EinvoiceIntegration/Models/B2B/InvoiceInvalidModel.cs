using System;
using System.ComponentModel.DataAnnotations;

namespace EinvoiceIntegration.Models.B2B
{
    public class InvoiceInvalidModel : BaseModel
    {
        [Required]
        [Display(Name = "發票號碼")]
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$")]
        public string InvoiceNumber { get; set; }
        
        [Required]
        [Display(Name = "發票日期")]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "作廢原因")]
        public string Reason { get; set; }

        [Display(Name = "備註")]
        public string Remark { get; set; }
    }
}
