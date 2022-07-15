using EinvoiceIntegration.Attributes;

namespace EinvoiceIntegration.Enum
{
    public enum PayTypeEnum
    {
        /// <summary>
        /// Allpay
        /// </summary>
        [Text("1")]
        ALLPAY = 1,

        /// <summary>
        /// ECPay
        /// </summary>
        [Text("2")]
        ECPAY = 2,


        /// <summary>
        /// ECBank
        /// </summary>
        [Text("3")]
        ECBANK = 3
    }
}
