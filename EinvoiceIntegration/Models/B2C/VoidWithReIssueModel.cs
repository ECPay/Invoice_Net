using System.ComponentModel.DataAnnotations;

namespace EinvoiceIntegration.Models.B2C
{
    public class VoidWithReIssueModel : BaseModel
    {
        [Required]
        [Display(Name = "開立發票參數")]
        public InvoiceIssueModel IssueModel { get; set; }

        [Required]
        [Display(Name = "開立註銷參數")]
        public VoidModel VoidModel { get; set; }
    }
}
