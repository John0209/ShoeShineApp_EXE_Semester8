using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.ResponeModel
{
    public class CartResponse
    {
        public int Id { get; set; }
        public string NameService { get; set; } = string.Empty;
        public string NameCategory { get; set; } = string.Empty;
        public float PriceService { get; set; } 
    }
}
