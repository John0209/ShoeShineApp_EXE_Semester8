using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.ResponeModel
{
    public class StoreRegistrationRespone
    {
        [Required(ErrorMessage = "StoreName is required.")]
        [StringLength(100, ErrorMessage = "StoreName must not exceed 100 characters.")]
        public string? StoreName { get; set; }

        [Required(ErrorMessage = "StoreAddress is required.")]
        [StringLength(200, ErrorMessage = "StoreAddress must not exceed 200 characters.")]
        public string? StoreAddress { get; set; }

        [Required(ErrorMessage = "StorePhone is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "StorePhone must be 10 digits.")]
        public string? StorePhone { get; set; }

        [Required(ErrorMessage = "StoreEmail is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? StoreEmail { get; set; }
        
    }
}
