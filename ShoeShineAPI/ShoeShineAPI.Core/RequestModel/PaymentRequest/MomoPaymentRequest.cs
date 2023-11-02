using Microsoft.AspNetCore.Mvc;
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
    [BindProperties]
    public class MomoPaymentRequest
    {
        [JsonIgnore]
        public string partnerCode { get; set; } = "";
        
        public string requestId { get; set; } = string.Empty;
        [JsonIgnore]
        public string ipnUrl { get; set; } = "";
        [JsonIgnore]
        public long amount { get; set; } = 0;
        [JsonIgnore]
        public string orderId { get; set; } = string.Empty;
        [JsonIgnore]
        public string orderInfo { get; set; } ="ShoeShine Service";
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
        [JsonIgnore]
        public string transactionType { get; set; } = "";

    }
}
