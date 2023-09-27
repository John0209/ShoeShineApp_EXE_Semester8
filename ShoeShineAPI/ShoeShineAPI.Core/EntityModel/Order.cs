using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.EntityModel
{
    public class Order
    {
        public int OrderId { get; set; }
        //FK
        public int PaymentId { get; set; }
        public Guid UserId { get; set; }
        public string OrderCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public float TotalPrice { get; set; }
        //RelationShip
        public Payment? Payment { get; set; }
        public User? User { get; set; }
        public OrderDetail? OrderDetail { get; set; }
    }
}
