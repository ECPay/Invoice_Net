using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Ecpay.EInvoice.Integration.Enumeration;

namespace Ecpay.EInvoice.Integration.Attributes
{
    /// <summary>
    /// 依據載具類型檢查該欄位(載具編號)是否為正確格式的類別。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RequiredByCarruerTypeNumFormatAttribute : RequiredAttribute
    {
        /// <summary>
        /// 依據載具類型檢查該欄位是否必填的類別建構式。
        /// </summary>
        public RequiredByCarruerTypeNumFormatAttribute() : base() { }

        /// <summary>
        /// 是否檢核通過。
        /// </summary>
        /// <param name="value">要檢核的物件類別。</param>
        /// <returns>驗證成功為 True 否則為 False。</returns>
        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection pdcProperties = null;

            object[] oValues = (object[])value;

            object oPropertyName = oValues[0]; // 屬性的名稱。
            object oPropertyValue = oValues[1]; // 屬性的值。
            object oSourceComponent = oValues[2]; // 該屬性所屬物件。

            // 不可為 Null，但允許空字串。
            bool isValid = (oPropertyValue != null);

            // 特殊驗證：當載具類別自然人憑證號碼時，須有值、長度固定16碼、格式為2碼大小寫字母加上14碼數字。
            if (oPropertyName.Equals("CarruerNum"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("carruerType", false).GetValue(oSourceComponent);

                if (oNeedCheckedValue.Equals(CarruerTypeEnum.NaturalPersonEvidence) && !Regex.IsMatch(Convert.ToString(oPropertyValue), @"^[A-Za-z]{2}[0-9]{14}$"))
                {
                    return false;
                }
                if (oNeedCheckedValue.Equals(CarruerTypeEnum.PhoneBarcode) && !Regex.IsMatch(Convert.ToString(oPropertyValue), @"^/[+-. 0-9a-zA-Z]{7}$"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}