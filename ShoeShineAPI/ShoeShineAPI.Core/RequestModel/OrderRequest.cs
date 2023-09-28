using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class OrderRequest
    {
        [JsonIgnore]
        public int OrderId { get; set; } = 0;
        //FK
        [Required]
        public int PaymentId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public string OrderCode { get; set; } = "";
        [StringLength(100,ErrorMessage ="You are allowed to enter less than 100 characters")]
        public string Address { get; set; } = string.Empty;
        [Range(1000,10000000,ErrorMessage ="You are allowed to enter value from 1.000 to 10.000.000")]
        public float TotalPrice { get; set; }
        [Range(1000, 50000, ErrorMessage = "You are allowed to enter value from 1.000 to 50.000")]
        public float Shipfee { get; set; }
        [Range(1, 10, ErrorMessage = "You are allowed to enter value from 1 to 10")]
        public int QuantityItem { get; set; }
        [JsonIgnore]
        public int IsOrderStatus { get; set; } = 1;
    }
}
