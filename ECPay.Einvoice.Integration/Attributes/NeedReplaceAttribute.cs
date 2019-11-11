using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecpay.EInvoice.Integration.Attributes
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
    internal class NeedReplaceAttribute: Attribute
    {
        /// <summary>
        /// 表示需要Replace動作。
        /// </summary>
        public NeedReplaceAttribute()
        {

        }
    }
}
