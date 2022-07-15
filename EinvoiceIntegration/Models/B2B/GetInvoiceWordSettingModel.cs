using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models.B2B
{
    public class GetInvoiceWordSettingModel : BaseModel
    {

        /// <summary>
        /// 發票期別
        /// 0:全部, 1: 1-2月 ,2: 3-4月 ,3: 5-6月 ,4: 7-8月 ,5: 9-10月 ,6: 11-12月
        /// </summary>
        [Required]
        [Display(Name = "發票期別")]
        [RegularExpression(@"^[0-6]{1}$")]
        public int? InvoiceTerm { get; set; }

        /// <summary>
        /// 發票年度
        /// </summary>
        [Required]
        [Display(Name = "發票年度")]
        [RegularExpression(@"^[0-9]{1,3}$")]
        public string InvoiceYear { get; set; }

        /// <summary>
        /// 字軌使用狀態
        /// 0:全部, 1:未啟用, 2:使用中, 3:已停用, 4:暫停中, 5:待審核, 6:審核不通過
        /// </summary>
        [Required]
        [Display(Name = "字軌使用狀態")]
        [RegularExpression(@"^[0-6]{1}$")]
        public int? UseStatus { get; set; }

        /// <summary>
        /// 發票類別
        /// 0:全部, 1:B2C, 2:B2B
        /// </summary>
        [Required]
        [Display(Name = "發票類別")]
        [RegularExpression(@"^[0-2]{1}$")]
        public int? InvoiceCategory { get; set; }

        /// <summary>
        /// 字軌類別
        /// 07:一般稅額
        /// 08:特種稅額計
        /// </summary>
        [Display(Name = "字軌類別")]
        [StringLength(2)]
        [RegularExpression(@"^07|08$")]
        public string InvType { get; set; }

        /// <summary>
        /// 字軌名稱
        /// </summary>
        [Display(Name = "字軌名稱")]
        [StringLength(2)]
        public string InvoiceHeader { get; set; }
    }
}
