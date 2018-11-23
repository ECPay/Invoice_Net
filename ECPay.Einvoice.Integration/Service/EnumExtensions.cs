using System;
using System.Reflection;
using Ecpay.EInvoice.Integration.Attributes;

namespace Ecpay.EInvoice.Integration.Service
{
    public static class EnumExtender
    {
        public static string ToText(this Enum enumeration)
        {
            MemberInfo[] memberInfo = enumeration.GetType().GetMember(enumeration.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(TextAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    return ((TextAttribute)attributes[0]).Text;
                }
            }
            return enumeration.ToString();
        }
    }
}