using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class AllowanceInvalidModel : BaseModel
    {
        /// <summary>
        /// 折讓單號
        /// </summary>
        [Required]
        [Display(Name = "折讓編號")]
        [StringLength(16, MinimumLength = 1, ErrorMessage = "{0} 格式錯誤")]
        [RegularExpression("[A-Za-z0-9]{1,16}", ErrorMessage = "{0} 格式錯誤")]
        public string AllowanceNo { get; set; }
        /// <summary>
        /// 發票號碼
        /// </summary>
        [Required]
        [Display(Name = "發票號碼")]
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$", ErrorMessage = "{0} 格式錯誤")]
        public string InvoiceNo { get; set; }
        /// <summary>
        /// 作廢原因
        /// </summary>
        [Required]
        [Display(Name = "作廢原因")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "{0} 格式錯誤")]
        public string Reason { get; set; }
    }
}
