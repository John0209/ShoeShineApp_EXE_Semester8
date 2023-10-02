using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.RequestModel.PaymentRequest;
using ShoeShineAPI.Gateway.IConfig;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService _payment;
        IMapper _map;
        IMomoConfig _momoConfig;

        public PaymentController(IPaymentService payment, IMapper map, IMomoConfig momoConfig)
        {
            _payment = payment;
            _map = map;
            _momoConfig = momoConfig;
        }

        [HttpPost("momo")]
        public IActionResult CreatePaymentMomo([FromBody] MomoPaymentRequest paymentRequest)
        {
            paymentRequest.redirectUrl = _momoConfig.ReturnUrl;
            paymentRequest.ipnUrl = _momoConfig.IpnUrl;
            paymentRequest.partnerCode = _momoConfig.PartnerCode;
            paymentRequest.signature= _payment.MakeSignatureMomoPayment
                (_momoConfig.AccessKey, _momoConfig.SecretKey, paymentRequest);
            // lấy link QR momo
            var result= _payment.GetLinkGatewayMomo(_momoConfig.PaymentUrl, paymentRequest);
            if (result.Item1) return Ok(result.Item2);
            return BadRequest(result);
        }
    }
}
