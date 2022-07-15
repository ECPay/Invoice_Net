using EinvoiceIntegration.Models;
using System.Collections.Generic;

namespace EinvoiceIntegration.Interfaces
{
    public interface IApiUrlModel
    {
        List<ApiUrl> GetList();
    }
}
