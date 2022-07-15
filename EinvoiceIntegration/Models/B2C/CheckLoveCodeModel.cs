using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Models.B2C
{
    public class CheckLoveCodeModel : BaseModel
    {
        /// <summary>
        /// 捐贈碼
        /// </summary>
        [Required]
        [Display(Name = "捐贈碼")]
        [RegularExpression(@"^\d{3,7}$", ErrorMessage = "{0} 為3~7碼純數字")]
        public string LoveCode { get; set; }
    }
}
