using System;

namespace Ecpay.EInvoice.Integration.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
    internal class StringFormatAttribute : Attribute
    {
        public string Format { get; }

        /// <summary>
        /// 完全不處理。
        /// </summary>
        public StringFormatAttribute(string format)
            : base()
        {
            Format = format;
        }
    }
}