using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiLab0904.Controllers
{
    public class ProductPatchVM : IValidatableObject
    {
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<decimal> Stock { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}