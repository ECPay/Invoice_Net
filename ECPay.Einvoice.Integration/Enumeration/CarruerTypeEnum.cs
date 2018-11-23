using Ecpay.EInvoice.Integration.Attributes;

namespace Ecpay.EInvoice.Integration.Enumeration
{
    public enum CarruerTypeEnum : int
    {
        /// <summary>
        /// 無。
        /// </summary>
        [Text("")]
        None = 0,

        /// <summary>
        /// 歐付寶會員。
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