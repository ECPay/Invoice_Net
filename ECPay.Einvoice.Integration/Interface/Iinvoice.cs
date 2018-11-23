using Ecpay.EInvoice.Integration.Enumeration;

namespace Ecpay.EInvoice.Integration.Interface
{
    /// <summary>
    /// 發票類別
    /// </summary>
    public interface Iinvoice
    {
        InvoiceMethodEnum invM { get; }
    }
}