using System;

namespace EinvoiceIntegration.Attributes
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
