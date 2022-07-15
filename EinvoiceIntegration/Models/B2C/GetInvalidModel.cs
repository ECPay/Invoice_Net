using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Models.B2C
{
    public class GetInvalidModel : BaseModel
    {
        /// <summary>
        /// 發票開立日期
        /// </summary>
        [Required]
        [Display(Name = "發票開立日期")]
        [Range(typeof(DateTime), "1970-01-01 00:00:00", "3000-12-31 23:59:59", ErrorMessage = "發票開立日期錯誤")]
        public DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// 發票號碼
        /// </summary>
        [Required]
        [Display(Name = "發票號碼")]
        [StringLength(10)]
        public string InvoiceNo { get; set; }
        /// <summary>
        /// 特店自訂編號
        /// </summary>
        [Required]
        [Display(Name = "特店自訂編號")]
        [StringLength(30, ErrorMessage = "{0} 格式錯誤")]
        public string RelateNumber { get; set; }
    }
}
