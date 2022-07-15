using System.ComponentModel.DataAnnotations;

namespace EinvoiceIntegration.Models.B2C
{
    /// <summary>
    /// 取消待開立發票 API Params 
    /// </summary>
    public class CancelDelayIssueModel : BaseModel
    {

        /// <summary>
        /// 交易單號
        /// 
        /// PS: 交易單號是唯一的編號
        /// </summary>
        [Display(Name = "交易單號")]
        [StringLength(30)]
        public string Tsr { get; set; }
         
    }
}