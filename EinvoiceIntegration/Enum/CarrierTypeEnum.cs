using EinvoiceIntegration.Attributes;

namespace EinvoiceIntegration.Enum
{
    public enum CarrierTypeEnum
    {
        /// <summary>
        /// 無
        /// </summary>
        [Text("")]
        None = 0,

        /// <summary>
        /// 綠界會員載具
        /// </summary>
        [Text("1")]
        Member = 1,

        /// <summary>
        /// 自然人憑證。
        /// </summary>
        [Text("2")]
        NaturalPersonEvidence = 2,

        /// <summary>
        /// 手機條碼。
        /// </summary>
        [Text("3")]
        PhoneBarcode = 3
    }
}
