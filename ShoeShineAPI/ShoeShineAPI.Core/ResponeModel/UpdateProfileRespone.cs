using ShoeShineAPI.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.ResponeModel
{
    public class UpdateProfileRespone
    {
        public string Name { get; set; }

        [Required]
        public EnumClass.Gender Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; }
    }
}
