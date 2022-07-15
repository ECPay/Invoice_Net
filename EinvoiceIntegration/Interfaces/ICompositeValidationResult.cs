using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EinvoiceIntegration.Interfaces
{
    public interface ICompositeValidationResult
    {
        IEnumerable<ValidationResult> Results { get; }
    }
}
