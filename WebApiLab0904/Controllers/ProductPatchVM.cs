using System;

namespace WebApiLab0904.Controllers
{
    public class ProductPatchVM
    {
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Stock { get; set; }
    }
}