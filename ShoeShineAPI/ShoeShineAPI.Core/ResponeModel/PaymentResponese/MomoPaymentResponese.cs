using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.ResponeModel.PaymentResponese
{
    [BindProperties]
    public class MomoPaymentResponese
    {
        public string partnerCode { get; set; } = string.Empty;
        public string requestId { get; set; } = string.Empty;
        public string amount { get; set; } = string.Empty;
        public string orderId { get; set; } = string.Empty;
        public string payUrl { get; set; } = string.Empty;
        public string resultCode { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public string responseTime { get; set; } = string.Empty;
    }
}
