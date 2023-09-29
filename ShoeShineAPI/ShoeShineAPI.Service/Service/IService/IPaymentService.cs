using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShineAPI.Core.RequestModel.PaymentRequest;
namespace ShoeShineAPI.Service.Service.IService
{
    public interface IPaymentService
    {
        public string MakeSignatureMomoPayment(string accessKey, string secretKey, MomoPaymentRequest momo);
        public (bool, string?) GetLinkGatewayMomo(string paymentUrl, MomoPaymentRequest momoPaymentRequest);
    }
}
