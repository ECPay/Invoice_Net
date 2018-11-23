namespace Ecpay.EInvoice.Integration.Enumeration
{
    /// <summary>
    /// 延遲註記
    /// </summary>
    public enum DelayFlagEnum : int
    {
        /// <summary>
        /// 一般延遲
        /// </summary>
        NormalDelay = 1,

        /// <summary>
        /// 觸發延遲
        /// </summary>
        TriggerDelay = 2
    }
}