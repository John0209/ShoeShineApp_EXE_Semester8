using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class OrderRequest
    {
        public int OrderId { get; set; }
        //FK
        public int PaymentId { get; set; }
        public Guid UserId { get; set; }
        public string OrderCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public float TotalPrice { get; set; }
        public int IsOrderStatus { get; set; }
    }
}
