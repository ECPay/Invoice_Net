using EinvoiceIntegration.Enum.B2C;

namespace EinvoiceIntegration.Interfaces
{
    interface IB2CInvoice
    {
        B2CInvoiceMethod b2CInvoiceMethod { get; }
    }
}
