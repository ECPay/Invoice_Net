using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ecpay.EInvoice.Integration.Enumeration;
using System.Text.RegularExpressions;

namespace Ecpay.EInvoice.Integration.Attributes
{
    /// <summary>
    /// 依據課稅別檢查該欄位是否必填的類別。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RequiredByTaxTypeAttribute : RequiredAttribute
    {
        /// <summary>
        /// 依據課稅別檢查該欄位是否必填的類別建構式。
        /// </summary>
        public RequiredByTaxTypeAttribute() : base() { }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection pdcProperties = null;

            object[] oValues = (object[])value;

            object oPropertyName = oValues[0]; // 屬性的名稱。
            object oPropertyValue = oValues[1]; // 屬性的值。
            var oSourceComponent = (Ecpay.EInvoice.Integration.Models.InvoiceCreate)oValues[2]; // 該屬性所屬物件。

            //特殊驗證：當稅別為零稅率時(ZeroTaxRate)，通關方式只能為非經海關出口或經海關出口。
            //          當稅別為非零稅率時，通關方式為無。
            if (oPropertyName.Equals("ClearanceMark"))
            {
                var oTaxType = oSourceComponent.TaxType;
                var sItemTaxType = oSourceComponent.ItemTaxType;

                //#55880 修改為和API同樣判斷邏輯
                if (oTaxType.Equals(TaxTypeEnum.ZeroTaxRate) || Regex.IsMatch(sItemTaxType, "[2]{1}"))
                {
                    if (!(oPropertyValue.Equals(CustomsClearanceMarkEnum.No) || oPropertyValue.Equals(CustomsClearanceMarkEnum.Yes)))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!oPropertyValue.Equals(CustomsClearanceMarkEnum.None))
                        return false;
                }
            }

            return true;
        }
    }
}