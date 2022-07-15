using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class AllowanceConfirmModel : BaseModel
    {
        /// <summary>
        /// 折讓單號
        /// </summary>
        [Required]
        public string AllowanceNo { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [StringLength(200)]
        public string Remark { get; set; }
    }
}
