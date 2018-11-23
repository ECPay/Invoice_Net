namespace Ecpay.EInvoice.Integration.Enumeration
{
    /// <summary>
    /// 發票捐贈類型。
    /// </summary>
    public enum DonationEnum : int
    {
        /// <summary>
        /// 捐贈發票。 (捐贈)時，不可選擇列印(不列印)。
        /// </summary>
        Yes = 1,

        /// <summary>
        /// 不捐贈發票。
        /// </summary>
        No = 2
    }
}