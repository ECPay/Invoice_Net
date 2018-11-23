namespace Ecpay.EInvoice.Integration.Enumeration
{
    /// <summary>
    /// 課稅類型。
    /// </summary>
    public enum TaxTypeEnum : int
    {
        /// <summary>
        /// 應稅
        /// </summary>
        Taxable = 1,

        /// <summary>
        /// 零稅率
        /// </summary>
        ZeroTaxRate = 2,

        /// <summary>
        /// 免稅
        /// </summary>
        DutyFree = 3,

        /// <summary>
        /// 混合應稅
        /// </summary>
        MixedTaxable = 9
    }
}