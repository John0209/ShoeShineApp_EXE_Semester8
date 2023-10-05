using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel.PaymentRequest
{
    [BindProperties]
    public class MomoResultRequest
    {
        public string partnerCode { get; set; } = "";
        public string orderId { get; set; } = "";
        public string requestId { get; set; } = "";
       
        public string orderInfo { get; set; } = "";
        public string orderType { get; set; } = "momo_wallet";
        public string transId { get; set; } = "";
        
        public string message { get; set; } = "";
        public string payType { get; set; } = "";
        public string signature { get; set; } = "";
        public string extraData { get; set; } = "";
        public int resultCode { get; set; } = 0;
        public long amount { get; set; } = 0;
        public long responseTime { get; set; } = 0;

    }
}
