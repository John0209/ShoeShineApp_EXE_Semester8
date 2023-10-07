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
        public int PaymentMethodId { get; set; }
        public Guid UserId { get; set; }
        public string OrderCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int IsOrderStatus { get; set; }// 0. await payment, 1. confirm, 2. shipping, 3. receive, 4. cancel
        //RelationShip
        public PaymentMethod? PaymentMethod { get; set; }
        public User? User { get; set; }
        public OrderDetail? OrderDetail { get; set; }
        public Transaction? Transaction { get; set; }
    }
}
