using System.ComponentModel.DataAnnotations;

namespace EinvoiceIntegration.Models.B2C
{
    public class VoidModel : BaseModel
    {
        [Required]
        [Display(Name = "發票號碼")]
        [StringLength(10)]
        public string InvoiceNo { get; set; }

        [Required]
        [Display(Name = "註銷原因")]
        [StringLength(20)]
        public string VoidReason { get; set; }
    }
}
