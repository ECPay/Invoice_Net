using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class GetInvalidModel : BaseModel
    {
        /// <summary>
        /// 發票類別 0:銷項發票,1:進項發票
        /// </summary>
        [Required]
        [Range(0, 1)]
        public byte? InvoiceCategory { get; set; }
        /// <summary>
        /// 發票開立日期
        /// </summary>
        public DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// 發票號碼
        /// </summary>
        [RegularExpression(@"^[A-Z]{2}[\d]{8}$")]
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// 自訂編號
        /// </summary>
        public string RelateNumber { get; set; }
    }
}
