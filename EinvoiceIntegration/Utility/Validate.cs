using EinvoiceIntegration.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EinvoiceIntegration.Utility
{
    public class Validate
    {
        /// <summary>
        /// //Model 通用檢查
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="errorMessage">檢查失敗訊息</param>
        /// <returns></returns>
        public bool IsValid(object model, ref string errorMessage)
        {
            System.Collections.Specialized.NameValueCollection errors = null;
            if (!TryValidateObject(model, ref errors))
            {
                errorMessage = GenerateValidateMsg(errors);

                return false;
            }

            return true;
        }

        private NameValueCollection GetValidateResult(List<ValidationResult> errors, string field = null)
        {
            NameValueCollection _errors = new NameValueCollection();

            if (field == null)
            {
                field = string.Empty;
            }

            foreach (ValidationResult r in errors)
            {
                var iComposite = r as ICompositeValidationResult;

                string memberName = r.MemberNames.FirstOrDefault() ?? string.Empty;

                if (!string.IsNullOrEmpty(field))
                {
                    if (!memberName.StartsWith("["))
                    {
                        memberName = field + "." + memberName;
                    }
                    else
                    {
                        memberName = field + memberName;
                    }
                }

                if (iComposite == null)
                {
                    _errors.Add(memberName, r.ErrorMessage);
                }
                else
                {
                    NameValueCollection nvc = GetValidateResult(iComposite.Results.ToList(), memberName);

                    _errors.Add(nvc);
                }
            }

            return _errors;
        }

        /// <summary>
        /// 驗證 Model
        /// </summary>
        /// <param name="model">待驗證物件</param>
        /// <param name="_errors">驗證錯誤結果</param>
        /// <returns>驗證是否正確</returns>
        public bool TryValidateObject(object model, ref NameValueCollection _errors)
        {
            ValidationContext vldCtx = new ValidationContext(model, null, null);

            //檢核錯誤會被放入集合
            //注意第四個參數，要填true，才會檢核Required以外的ValidationAttribute
            //參數名稱(validateAllProperties)有誤導之嫌
            //已有網友在Connect反應: http://goo.gl/zllLw
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Validator.TryValidateObject(model, vldCtx, errors, true)) return true;

            _errors = GetValidateResult(errors);

            return false;
        }

        /// <summary>
        /// 取得驗證集合結果(斷行顯示)
        /// </summary>
        /// <param name="nv">驗證結果</param>
        /// <returns></returns>
        public string GenerateValidateMsg(NameValueCollection nv)
        {
            string msg = string.Empty;

            string[] keys = nv.AllKeys;

            for (int i = 0; i < keys.Length; i++)
            {
                string key = keys[i];

                msg += string.Format("[{0}] {1}", key, nv[key]);

                if (i < keys.Length - 1)
                {
                    msg += Environment.NewLine;
                }
            }

            return msg;
        }
    }
}
