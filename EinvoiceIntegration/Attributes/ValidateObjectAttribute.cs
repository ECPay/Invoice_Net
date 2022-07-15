using EinvoiceIntegration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Attributes
{
    /// <summary>
    /// 巢狀物件驗證
    /// </summary>
    public class ValidateObjectAttribute : ValidationAttribute
    {
        /// <summary>
        /// 驗證
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(value, null, null);

            IEnumerable<object> aryObj = value as IEnumerable<object>;

            if (aryObj == null)
            {
                Validator.TryValidateObject(value, context, results, true);
            }
            else
            {
                List<object> array = aryObj.ToList();
                for (int i = 0; i < array.Count; i++)
                {
                    object obj = array[i];

                    var objContext = new ValidationContext(obj, null, null);

                    var objResults = new List<ValidationResult>();

                    if (!Validator.TryValidateObject(obj, objContext, objResults, true))
                    {
                        foreach (ValidationResult error in objResults)
                        {
                            var memberNames = error.MemberNames.Select(t => string.Format("[{0}].{1}", i, t)).ToList();

                            results.Add(new ValidationResult(error.ErrorMessage, memberNames));
                        }
                    }
                }
            }

            if (results.Count != 0)
            {
                string errorMessage = string.Format("Validation for {0} failed!", validationContext.DisplayName);
                string[] memberNames = new string[] { validationContext.MemberName };
                var compositeResults = new CompositeValidationResult(errorMessage, memberNames);
                results.ForEach(compositeResults.AddResult);
                return compositeResults;
            }

            return ValidationResult.Success;
        }
    }
}
