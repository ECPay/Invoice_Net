using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class RejectConfirmModel : BaseModel
    {
        /// <summary>
        /// 發票開立日期
        /// </summary>
        [Display(Name = "發票開立日期")]
        [Required]
        public DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// 發票號碼
        /// </summary>
        [Required]
        [Display(Name = "發票號碼")]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$", ErrorMessage = "{0} 格式錯誤")]
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [StringLength(200)]
        public string Remark { get; set; }
    }
}
