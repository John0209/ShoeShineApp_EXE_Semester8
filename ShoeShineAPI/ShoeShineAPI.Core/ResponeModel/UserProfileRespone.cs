using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShineAPI.Enum;

namespace ShoeShineAPI.Core.ResponeModel
{
    public class UserProfileRespone
    {
        public string Name { get; set; }
        public EnumClass.Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
