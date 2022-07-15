using EinvoiceIntegration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Enum
{
    /// <summary>
    /// 課稅類型
    /// </summary>
    public enum TaxTypeEnum
    {
        /// <summary>
        /// 應稅
        /// </summary>
        [Text("1")]
        Taxable = 1,

        /// <summary>
        /// 零稅率
        /// </summary>
        [Text("2")]
        ZeroTaxRate = 2,

        /// <summary>
        /// 免稅
        /// </summary>
        [Text("3")]
        DutyFree = 3,

        /// <summary>
        /// 特種稅率
        /// </summary>
        [Text("4")]
        SpecTax = 4,

        /// <summary>
        /// 混合應稅
        /// </summary>
        [Text("9")]
        MixedTaxable = 9
    }
}
