using EinvoiceIntegration.Attributes;

namespace EinvoiceIntegration.Enum
{
    public enum VatEnum
    {
        /// <summary>
        /// 未稅價
        /// </summary>
        [Text("0")]
        No = 0,

        /// <summary>
        /// 含稅價
        /// </summary>
        [Text("1")]
        Yes = 1
    }
}
