using EinvoiceIntegration.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Models
{
    /// <summary>
    /// 混合驗證結果
    /// </summary>
    public class CompositeValidationResult : ValidationResult, ICompositeValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();

        /// <summary>
        /// 驗證結果集合
        /// </summary>
        public IEnumerable<ValidationResult> Results
        {
            get
            {
                return _results;
            }
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="errorMessage"></param>
        public CompositeValidationResult(string errorMessage) : base(errorMessage) { }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="memberNames"></param>
        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames) { }

        /// <summary>
        /// 新增驗證結果
        /// </summary>
        /// <param name="validationResult"></param>
        public void AddResult(ValidationResult validationResult)
        {
            _results.Add(validationResult);
        }

        /// <summary>
        /// 移除驗證結果
        /// </summary>
        /// <param name="validationResult"></param>
        public void RemoveResult(ValidationResult validationResult)
        {
            _results.Remove(validationResult);
        }
    }
}
