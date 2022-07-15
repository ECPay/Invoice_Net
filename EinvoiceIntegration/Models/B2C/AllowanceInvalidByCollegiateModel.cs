using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class AllowanceInvalidByCollegiateModel : AllowanceInvalidModel
    {
        /// <summary>
        /// 操作者
        /// </summary>
        [StringLength(20)]
        public string CreateUser { get; set; }
    }
}
