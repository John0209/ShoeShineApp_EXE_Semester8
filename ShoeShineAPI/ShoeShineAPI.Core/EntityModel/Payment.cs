using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.EntityModel
{
    public class Payment
    {
        public int PaymentId { get; set; }
        //FK
        public int PaymentMethodId { get; set; }
        public float Amount { get; set; }
        public string AddInformation { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
      
        //Relationship
        public PaymentMethod? PaymentMethod { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
