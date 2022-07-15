namespace EinvoiceIntegration.Models
{
    public class ApiRpModelBase
    {
        public long PlatformID { get; set; }
        public long MerchantID { get; set; }
        public ApiHeaderModel RpHeader { get; set; }
        public int TransCode { get; set; }
        public string TransMsg { get; set; }
    }
}
