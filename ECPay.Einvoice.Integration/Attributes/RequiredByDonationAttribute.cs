using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Enumeration;

namespace Ecpay.EInvoice.Integration.Attributes
{
    /// <summary>
    /// 依據是否捐贈電子發票檢查該欄位是否必填的類別。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RequiredByDonationAttribute : RequiredAttribute
    {
        /// <summary>
        /// 依據是否捐贈電子發票檢查該欄位是否必填的類別建構式。
        /// </summary>
        public RequiredByDonationAttribute() : base() { }

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

            //當捐贈時，LoveCode不可空白。
            if (oPropertyName.Equals("LoveCode"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("Donation", true).GetValue(oSourceComponent);

                if (oNeedCheckedValue.Equals(DonationEnum.Yes))
                {
                    return base.IsValid(oPropertyValue);
                }
            }
            //當捐贈時，列印註記不可為1(列印)。
            if (oPropertyName.Equals("Print"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("Donation", true).GetValue(oSourceComponent);

                if (oNeedCheckedValue.Equals(DonationEnum.Yes) && oPropertyValue.Equals(PrintEnum.Yes))
                {
                    return false;
                }
            }
            //當統一編號有值時，不可捐贈。
            if (oPropertyName.Equals("CustomerIdentifier"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("Donation", true).GetValue(oSourceComponent);

                if (oNeedCheckedValue.Equals(DonationEnum.Yes) && !string.IsNullOrEmpty(Convert.ToString(oPropertyValue)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}