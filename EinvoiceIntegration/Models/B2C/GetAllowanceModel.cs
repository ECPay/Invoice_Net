using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Models.B2C
{
    public class GetAllowanceModel : BaseModel
    {
        /// <summary>
        /// 折讓編號
        /// </summary>
        [Required]
        [Display(Name = "折讓編號")]
        [StringLength(16)]
        public string AllowanceNo { get; set; }
        /// <summary>
        /// 發票號碼
        /// </summary>
        [Required]
        [Display(Name = "發票號碼")]
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$")]
        public string InvoiceNo { get; set; }
    }
}
