using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Enumeration;

namespace Ecpay.EInvoice.Integration.Attributes
{
    /// <summary>
    /// 依據列印註記檢查欄位是否為必填的類別
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RequiredByPrintFlagAttribute : RequiredAttribute
    {
        /// <summary>
        /// 依據列印註記檢查欄位是否為必填的類別建構式
        /// </summary>
        public RequiredByPrintFlagAttribute() : base() { }

        /// <summary>
        /// 檢核是否通過
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection pdcProperties = null;

            object[] oValues = (object[])value;

            object oPropertyName = oValues[0]; // 屬性的名稱。
            object oPropertyValue = oValues[1]; // 屬性的值。
            object oSourceComponent = oValues[2]; // 該屬性所屬物件。

            // 不可為 Null，但允許空字串。
            bool isValid = (oPropertyValue != null);

            // 特殊驗證：當列印註記為1(列印)時，客戶名稱不可空白。
            if (oPropertyName.Equals("CustomerName"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("Print", true).GetValue(oSourceComponent);

                if (oNeedCheckedValue.Equals(PrintEnum.Yes))
                {
                    return base.IsValid(oPropertyValue);
                }
            }

            // 特殊驗證：當列印註記為1(列印)時，客戶地址不可空白。
            if (oPropertyName.Equals("CustomerAddr"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("Print", true).GetValue(oSourceComponent);

                if (oNeedCheckedValue.Equals(PrintEnum.Yes))
                {
                    return base.IsValid(oPropertyValue);
                }
            }

            //特殊驗證:當統編有值時，列印註記必為1(列印)
            if (oPropertyName.Equals("CustomerIdentifier"))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                oNeedCheckedValue = pdcProperties.Find("Print", true).GetValue(oSourceComponent);

                if (!string.IsNullOrEmpty(Convert.ToString(oPropertyValue)) && oNeedCheckedValue.Equals(PrintEnum.No))
                {
                    return false;
                }
            }

            return true;
        }
    }
}