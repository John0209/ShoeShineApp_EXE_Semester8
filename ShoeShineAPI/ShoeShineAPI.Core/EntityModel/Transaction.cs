using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.EntityModel
{
    public class Transaction
    {
        public string TransactionId { get; set; } = string.Empty;
        public float Amount { get; set; } = 0;
        public string TransactionType { get; set; } = string.Empty;
        public string TransactionInfor { get; set; } = string.Empty;
        public string PayType { get; set; } = string.Empty;
        //FK
        public int OrderId { get; set; } = 0;
        //Relationship
        public Order? Order { get; set; }
    }
}
