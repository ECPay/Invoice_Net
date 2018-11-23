using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Ecpay.EInvoice.Integration.Attributes;

namespace Ecpay.EInvoice.Integration.Service
{
    /// <summary>
    /// 伺服器端的 Model 驗證。
    /// </summary>
    internal static class ServerValidator
    {
        /// <summary>
        /// 要驗證的結構描述。
        /// </summary>
        /// <param name="source">主要驗證的元件。</param>
        /// <returns>驗證的訊息內容。</returns>
        public static IEnumerable<string> Validate(object source)
        {
            foreach (PropertyInfo propInfo in source.GetType().GetProperties())
            {
                var NeedDetailValid = propInfo.GetCustomAttributes(typeof(NeedDetailValidAttribute), inherit: true).FirstOrDefault();
                //當需要Detail驗證時
                if (NeedDetailValid != null)
                {
                    IEnumerable<object> tmp = (IEnumerable<object>)propInfo.GetValue(source, null);
                    foreach (var item in tmp)
                    {
                        foreach (PropertyInfo detailPropInfo in item.GetType().GetProperties())
                        {
                            object[] customAttributes = detailPropInfo.GetCustomAttributes(typeof(ValidationAttribute), inherit: true);

                            foreach (object customAttribute in customAttributes)
                            {
                                ValidationAttribute validationAttribute;
                                bool isValid;
                                ValidAttribute(item, detailPropInfo, customAttribute, out validationAttribute, out isValid);

                                if (!isValid)
                                {
                                    yield return validationAttribute.FormatErrorMessage(detailPropInfo.Name);
                                }
                            }
                        }
                    }
                }
                else
                {
                    object[] customAttributes = propInfo.GetCustomAttributes(typeof(ValidationAttribute), inherit: true);

                    foreach (object customAttribute in customAttributes)
                    {
                        ValidationAttribute validationAttribute;
                        bool isValid;
                        ValidAttribute(source, propInfo, customAttribute, out validationAttribute, out isValid);

                        #region 原始程式

                        //ValidationAttribute validationAttribute = (ValidationAttribute)customAttribute;

                        //bool isValid = false;
                        //// 預設驗證的 Attributes。
                        //if (validationAttribute.GetType() == typeof(RequiredAttribute) || validationAttribute.GetType() == typeof(RangeAttribute)
                        //    || validationAttribute.GetType() == typeof(RegularExpressionAttribute) || validationAttribute.GetType() == typeof(StringLengthAttribute))
                        //{
                        //    isValid = validationAttribute.IsValid(propInfo.GetValue(source, BindingFlags.GetProperty, null, null, null));
                        //}

                        //// 自訂驗證的 Attributes。
                        //else
                        //{
                        //    isValid = validationAttribute.IsValid(new object[] { propInfo.Name, propInfo.GetValue(source, BindingFlags.GetProperty, null, null, null), source });
                        //}

                        #endregion 原始程式

                        if (!isValid)
                        {
                            yield return validationAttribute.FormatErrorMessage(propInfo.Name);
                        }
                    }
                }
            }
        }

        private static void ValidAttribute(object item, PropertyInfo detailPropInfo, object customAttribute, out ValidationAttribute validationAttribute, out bool isValid)
        {
            validationAttribute = (ValidationAttribute)customAttribute;

            isValid = false;
            // 預設驗證的 Attributes。
            if (validationAttribute.GetType() == typeof(RequiredAttribute) || validationAttribute.GetType() == typeof(RangeAttribute)
                || validationAttribute.GetType() == typeof(RegularExpressionAttribute) || validationAttribute.GetType() == typeof(StringLengthAttribute))
            {
                isValid = validationAttribute.IsValid(detailPropInfo.GetValue(item, BindingFlags.GetProperty, null, null, null));
            }

            // 自訂驗證的 Attributes。
            else
            {
                isValid = validationAttribute.IsValid(new object[] { detailPropInfo.Name, detailPropInfo.GetValue(item, BindingFlags.GetProperty, null, null, null), item });
            }
        }
    }
}