namespace Ecpay.EInvoice.Integration.Enumeration
{
    /// <summary>
    /// 通關方式
    /// </summary>
    public enum CustomsClearanceMarkEnum : int
    {
        /// <summary>
        /// 若課稅類別不等於2(零稅率)時。
        /// </summary>
        None = 0,

        /// <summary>
        /// 若課稅類別等於2(零稅率)時，非經海關出口。
        /// </summary>
        No = 1,

        /// <summary>
        /// 若課稅類別等於2(零稅率)時，經海關出口。
        /// </summary>
        Yes = 2
    }
}