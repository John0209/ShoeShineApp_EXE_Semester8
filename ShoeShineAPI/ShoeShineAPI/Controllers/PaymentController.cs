using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.RequestModel.PaymentRequest;
using ShoeShineAPI.Gateway.IConfig;
using ShoeShineAPI.Service.Service.IService;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ShoeShineAPI.Core.ResponeModel.PaymentResponese;
using System.Transactions;
using Azure.Core;

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
        [HttpGet("qr")]
        public async Task<IActionResult> CreatePaymentQR()
        {
            var paymentRequest = new MomoPaymentRequest();
            var response = await _payment.MapOrderInformation(paymentRequest);
            if (response.Item1)
            {
                // gắn field
                paymentRequest = response.Item2;
                var resultRequest = new MomoResultRequest();
                resultRequest.amount = paymentRequest.amount;
                resultRequest.orderId = paymentRequest.orderId;
                resultRequest.requestId= paymentRequest.requestId;
                resultRequest.orderInfo = paymentRequest.orderInfo;
                resultRequest.orderType = "qr_code";
                resultRequest.payType = "qr";
                resultRequest.transId= paymentRequest.orderId;
                // Add transaction
                var result = await _payment.CreateTransaction(resultRequest);
                if (result) return Ok("Created Transaction Successful");
            }
            return Conflict("Created Transaction Failed");
        }
        [HttpGet("momo")]
        //[ProducesResponseType(link, 200)]
        public async Task<IActionResult> CreatePaymentMomo()
        {
           var paymentRequest= new MomoPaymentRequest();
           var response = await _payment.MapOrderInformation(paymentRequest);
           if(response.Item1)
            {
                paymentRequest = response.Item2;
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
            if (result) return Ok(new
            {
                status= "Payment Success!",
                result=resultRequest.resultCode
            });
            return BadRequest("Payment Fail!");
        }

    }
}
