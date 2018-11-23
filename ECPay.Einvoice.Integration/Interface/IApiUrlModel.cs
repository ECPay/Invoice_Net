using System;
using System.Collections.Generic;
using Ecpay.EInvoice.Integration.Service;

namespace Ecpay.EInvoice.Integration.Interface
{
    internal interface IApiUrlModel
    {
        List<ApiUrl> getlist();
    }
}