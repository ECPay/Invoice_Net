using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EinvoiceIntegration.Attributes
{
    /// <summary>
    /// 驗證 Email
    /// </summary>
    public sealed class ValidateEmailAttribute : ValidationAttribute
    {
        const string RegExString = @"^((([A-Za-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([A-Za-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([A-Za-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([A-Za-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([A-Za-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([A-Za-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([A-Za-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([A-Za-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([A-Za-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([A-Za-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";

        /// <summary>
        /// 建構式
        /// </summary>
        public ValidateEmailAttribute() { }

        public char[] separator { get; set; }

        /// <summary>
        /// 驗證
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (!(value is string))
            {
                return false;
            }

            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            string str = value.ToString();

            if (str == string.Empty)
            {
                return true;
            }

            if (str.Contains("\n"))
                return false;

            Regex regEx = new Regex(RegExString);
            ErrorMessage = FormatErrorMessage("Email");

            if (separator == null || separator.Length == 0)
            {
                if (str.Length != Encoding.UTF8.GetBytes(str).Length)
                    return false;

                return regEx.IsMatch(str);
            }
            else
            {
                var list = str.Split(separator);
                foreach (string _str in list)
                {
                    if (str.Length != Encoding.UTF8.GetBytes(str).Length) return false;
                    if (!regEx.IsMatch(_str)) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// 格式話錯誤訊息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage ?? string.Format("{0} 格式錯誤", name);
        }
    }
}
