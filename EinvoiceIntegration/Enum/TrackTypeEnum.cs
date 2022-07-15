using EinvoiceIntegration.Attributes;

namespace EinvoiceIntegration.Enum
{
    public enum TrackTypeEnum
    {
        /// <summary>
        /// 一般稅額
        /// </summary>
        [Text("07")]
        Normal = 7,

        /// <summary>
        /// 特種稅額
        /// </summary>
        [Text("08")]
        Special = 8
    }
}
