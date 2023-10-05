using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.RequestModel.PaymentRequest;
using ShoeShineAPI.Gateway.IConfig;
using ShoeShineAPI.Service.Service.IService;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ShoeShineAPI.Core.ResponeModel.PaymentResponese;
using System.Transactions;

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

        [HttpGet("momo")]
        //[ProducesResponseType(link, 200)]
        public async Task<IActionResult> CreatePaymentMomo()
        {
           var paymentRequest= new MomoPaymentRequest();
           var respone = await _payment.MapOrderInformation(paymentRequest);
           if(respone.Item1)
            {
                paymentRequest = respone.Item2;
                // lấy thuộc tính từ appsetting
                paymentRequest.redirectUrl = _momoConfig.ReturnUrl;
                paymentRequest.ipnUrl = _momoConfig.IpnUrl;
                paymentRequest.partnerCode = _momoConfig.PartnerCode;
                paymentRequest.signature = _payment.MakeSignatureMomoPayment
                (_momoConfig.AccessKey, _momoConfig.SecretKey, paymentRequest);
                // lấy link QR momo
                var result = _payment.GetLinkGatewayMomo(_momoConfig.PaymentUrl, paymentRequest);
                if (result.Item1) return Ok(result.Item2);
                return BadRequest(result.Item2);
            }
            return BadRequest("No Order Status Payment!");
        }
        [HttpGet]
        [Route("momo-return")]
        public async Task<IActionResult> MomoReturn([FromQuery] MomoResultRequest resultRequest)
        {
            var result = await _payment.CreateTransaction(resultRequest);
            if(result) return Ok("Payment Success!");
            return BadRequest("Payment Fail!");
        }

    }
}
