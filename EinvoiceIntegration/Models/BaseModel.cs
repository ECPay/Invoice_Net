using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Models
{
    public class BaseModel
    {
        /// <summary>
        /// 廠商編號
        /// </summary>
        [Required]
        [Display(Name = "廠商編號")]
        public long MerchantID { get; set; }
    }
}
