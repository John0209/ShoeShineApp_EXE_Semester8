using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel.PaymentRequest
{
    public class MomoPaymentRequest
    {
        [JsonIgnore]
        public string partnerCode { get; set; } = "";
        public string requestId { get; set; } = string.Empty;
        [JsonIgnore]
        public string ipnUrl { get; set; } = "";
        public long amount { get; set; } = long.MaxValue;
        [RegularExpression(@"^[0-9a-zA-Z]([-_.]*[0-9a-zA-Z]+)*$", ErrorMessage = "orderId format is invalid")]
        public string orderId { get; set; } = string.Empty;
        public string orderInfo { get; set; } = string.Empty;
        [JsonIgnore]
        public string redirectUrl { get; set; } = "";
        public string requestType { get; set; } = string.Empty;
        public string extraData { get; set; } = string.Empty;
        [JsonIgnore]
        public string lang { get; set; } = "vi";
        [JsonIgnore]
        public string signature { get; set; } = "";
       
    }
}
