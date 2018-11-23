using System;

namespace Ecpay.EInvoice.Integration.Attributes
{
    internal class TextAttribute : Attribute
    {
        public string Text;

        public TextAttribute(string text)
        {
            Text = text;
        }
    }
}