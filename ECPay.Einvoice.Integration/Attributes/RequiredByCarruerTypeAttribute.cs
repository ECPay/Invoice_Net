using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Enumeration;

namespace Ecpay.EInvoice.Integration
{
    /// <summary>
    /// 依據載具類型檢查該欄位是否必填的類別。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RequiredByCarruerTypeAttribute : RequiredAttribute
    {
        /// <summary>
        /// 依據載具類型檢查該欄位是否必填的類別建構式。
        /// </summary>
        public RequiredByCarruerTypeAttribute() : base() { }

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
            // 特殊驗證：當會員載具是歐付寶會員時時，客戶代號不可以為空值。
            if (oPropertyName.Equals("CustomerID"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("carruerType", false).GetValue(oSourceComponent);

                if (oNeedCheckedValue.Equals(CarruerTypeEnum.Member))
                {
                    return base.IsValid(oPropertyValue);
                }
            }
            // 特殊驗證：當載具自然人憑證號碼或手機條碼時，載具編號不可以為空值。
            else if (oPropertyName.Equals("CarruerNum"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("carruerType", false).GetValue(oSourceComponent);

                if (oNeedCheckedValue.Equals(CarruerTypeEnum.NaturalPersonEvidence) || oNeedCheckedValue.Equals(CarruerTypeEnum.PhoneBarcode))
                {
                    return base.IsValid(oPropertyValue);
                }
            }
            // 特殊驗證：當統一編號有值時，則載具類別不可為會員載具或自然人憑證載具。
            else if (oPropertyName.Equals("CustomerIdentifier"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("carruerType", false).GetValue(oSourceComponent);

                if ((oNeedCheckedValue.Equals(CarruerTypeEnum.Member) || oNeedCheckedValue.Equals(CarruerTypeEnum.NaturalPersonEvidence)) && !string.IsNullOrEmpty(Convert.ToString(oPropertyValue)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}