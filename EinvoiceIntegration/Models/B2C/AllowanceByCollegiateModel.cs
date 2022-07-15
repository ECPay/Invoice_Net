using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2C
{
    public class AllowanceByCollegiateModel : AllowanceModel
    {
        /// <summary>
        /// 消費者同意後回傳網址
        /// </summary>
        [Display(Name = "消費者同意後回傳網址")]
        [StringLength(200)]
        public string ReturnURL { get; set; }
    }
}
