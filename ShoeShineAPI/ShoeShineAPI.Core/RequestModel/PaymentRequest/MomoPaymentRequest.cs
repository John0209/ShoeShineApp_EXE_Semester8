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
        public string requestId { get; set; } = "A123";
        [JsonIgnore]
        public string ipnUrl { get; set; } = "";
        public long amount { get; set; } = 150000;
        [RegularExpression(@"^[0-9a-zA-Z]([-_.]*[0-9a-zA-Z]+)*$", ErrorMessage = "orderId format is invalid")]
        public string orderId { get; set; } = "A123";
        public string orderInfo { get; set; } = "TH TrueMilk 123 Star";
        [JsonIgnore]
        public string redirectUrl { get; set; } = "";
        [JsonIgnore]
        public string requestType { get; set; } = "captureWallet";
        [JsonIgnore]
        public string extraData { get; set; } = "eyJ1c2VybmFtZSI6ICJtb21vIn0=";
        [JsonIgnore]
        public string signature { get; set; } = "";
        [JsonIgnore]
        public string lang { get; set; } = "vi";
       
       
    }
}
