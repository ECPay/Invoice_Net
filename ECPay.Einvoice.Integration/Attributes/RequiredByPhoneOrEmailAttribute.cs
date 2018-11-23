using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ecpay.EInvoice.Integration.Attributes
{
    /// <summary>
    /// 依據手機或郵件檢查欄位則一填寫的類別
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RequiredByPhoneOrEmailAttribute : RequiredAttribute
    {
        /// <summary>
        /// 依據手機或郵件檢查欄位則一填寫的類別建構式
        /// </summary>
        public RequiredByPhoneOrEmailAttribute() : base() { }

        /// <summary>
        /// 手機或郵件擇一條件檢查用的參數。
        /// </summary>
        private string[] szaPhoneOrEmail = new string[] { "CustomerPhone", "CustomerEmail" };

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
            bool isValid = base.IsValid(oPropertyValue);
            // 特殊驗證：手機或郵件必須則一填寫(不可以為空字串)。
            if (!isValid && szaPhoneOrEmail.Contains(oPropertyName))
            {
                object oNeedCheckedValue = null;

                pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

                if (oPropertyName.Equals("CustomerPhone")) oNeedCheckedValue = pdcProperties.Find("CustomerEmail", true).GetValue(oSourceComponent);
                if (oPropertyName.Equals("CustomerEmail")) oNeedCheckedValue = pdcProperties.Find("CustomerPhone", true).GetValue(oSourceComponent);

                return base.IsValid(oNeedCheckedValue);
            }
            return true;
        }
    }
}