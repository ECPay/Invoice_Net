using EinvoiceIntegration.Enum;
using EinvoiceIntegration.Utility;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EinvoiceIntegration.Models.B2C
{
    public class TriggerIssueModel : BaseModel
    {
        private PayTypeEnum payTypeEnum;

        [JsonIgnore]
        public PayTypeEnum PayTypeEnum
        {
            get { return payTypeEnum; }
            set { payTypeEnum = value; }
        }

        /// <summary>
        /// 交易類別名稱
        /// </summary>
        [Required]
        [Display(Name = "交易類別名稱")]
        [StringLength(1)]
        public string PayType
        {
            get { return payTypeEnum.ToText(); }
        }

        /// <summary>
        /// 交易單號
        /// </summary>
        [Required]
        [Display(Name = "交易單號")]
        [StringLength(30)]
        public string Tsr { get; set; }
    }
}
