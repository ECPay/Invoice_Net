using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Models;

namespace Ecpay.EInvoice.Integration.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RequiredByItemCollectionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            object[] oValues = (object[])value;

            object oPropertyName = oValues[0]; // 屬性的名稱。
            object oPropertyValue = oValues[1]; // 屬性的值。
            object oSourceComponent = oValues[2]; // 該屬性所屬物件。

            if (oPropertyName.Equals("Items"))
            {
                var _items = (List<Item>)oPropertyValue;
                if (_items.Count == 0) return false;

                foreach (var item in _items)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(item.ItemName)))
                    {
                        ErrorMessage = "ItemName is required.";
                        return false;
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(item.ItemPrice)))
                    {
                        ErrorMessage = "ItemPrice is required.";
                        return false;
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(item.ItemAmount)))
                    {
                        ErrorMessage = "ItemAmount is required.";
                        return false;
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(item.ItemWord)))
                    {
                        ErrorMessage = "ItemWord is required.";
                        return false;
                    }
                    //if (item.ItemCount <= 0)
                    //{
                    //    ErrorMessage = "ItemCount must be greater than 0.";
                    //    return false;
                    //}
                }
            }

            return true;
        }
    }
}