using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiLab0904.Controllers
{
    public class ProductPatchVM
    {
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<decimal> Stock { get; set; }
    }
}