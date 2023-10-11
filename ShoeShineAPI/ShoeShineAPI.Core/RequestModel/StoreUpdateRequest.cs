using System.Text.Json.Serialization;
using ShoeShineAPI.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class StoreUpdateRequest
    {
        public int StoreId { get; set; }// Primary Key

        [Required(ErrorMessage = "StoreName is required.")]
        [StringLength(100, ErrorMessage = "StoreName must not exceed 100 characters.")]
        public string StoreName { get; set; } = string.Empty;

        [Required(ErrorMessage = "StoreAddress is required.")]
        [StringLength(200, ErrorMessage = "StoreAddress must not exceed 200 characters.")]
        public string StoreAddress { get; set; } = string.Empty;
        [MinLength(30, ErrorMessage ="Description least 30 characters")]
        public string StoreDescription { get; set; } = "Description Is Empty!";
        [Required(ErrorMessage = "StorePhone is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "StorePhone must be 10 digits.")]
        public string StorePhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "StoreEmail is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string StoreEmal { get; set; } = string.Empty;
       // [StringLength(150, ErrorMessage = "Url must not exceed 150 characters.")]
        public string[] Url { get; set;}= Array.Empty<string>();
    }
}
