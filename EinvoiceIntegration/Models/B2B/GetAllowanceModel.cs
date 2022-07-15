using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class GetAllowanceModel : BaseModel
    {
        /// <summary>
        /// 折讓單號
        /// </summary>
        [Required]
        public string AllowanceNo { get; set; }
    }
}
