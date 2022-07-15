using EinvoiceIntegration.Attributes;

namespace EinvoiceIntegration.Enum
{
    public enum CustomsClearanceMarkEnum
    {
        /// <summary>
        /// 若課稅類別不等於2(零稅率)時。
        /// </summary>
        [Text("")]
        None = 0,

        /// <summary>
        /// 若課稅類別等於2(零稅率)時，非經海關出口。
        /// </summary>
        [Text("1")]
        No = 1,

        /// <summary>
        /// 若課稅類別等於2(零稅率)時，經海關出口。
        /// </summary>
        [Text("2")]
        Yes = 2
    }
}
