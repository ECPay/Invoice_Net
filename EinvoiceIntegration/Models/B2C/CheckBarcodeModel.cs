using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Models.B2C
{
    public class CheckBarcodeModel : BaseModel
    {
        /// <summary>
        /// 手機載具
        /// </summary>
        [Required]
        [Display(Name = "手機載具")]
        [RegularExpression("^/[+-.0-9A-Z]{7,7}$", ErrorMessage = "{0} 為8碼，以/開頭的0-9A-Z+-.所組成之字串")]
        public string Barcode { get; set; }
    }
}
