namespace EinvoiceIntegration.Models
{
    public class SdkResult<T> : ApiRpModelBase
    {
        public T Data { get; set; }
    }
}
