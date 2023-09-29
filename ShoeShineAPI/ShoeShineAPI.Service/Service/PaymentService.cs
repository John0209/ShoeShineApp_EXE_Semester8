using Azure.Core;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.RequestModel.PaymentRequest;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.InheritanceClass;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShineAPI.Core.ResponeModel.PaymentResponese;

namespace ShoeShineAPI.Service.Service
{
    public class PaymentService : CommonAbstract<Payment>, IPaymentService
    {
        IUnitRepository _unit;

        public PaymentService(IUnitRepository unit)
        {
            _unit = unit;
        }

        protected override Task<IEnumerable<Payment>> GetAllDataAsync()
        {
            throw new NotImplementedException();
        }
        public string MakeSignatureMomoPayment(string accessKey, string secretKey, MomoPaymentRequest momo)
        {
            var rawHash = "accessKey=" + accessKey +
                "&amount=" + momo.amount +"&extraData=" + momo.extraData +
                "&ipnUrl=" + momo.ipnUrl +"&orderId=" + momo.orderId +
                "&orderInfo=" + momo.orderInfo +"&partnerCode=" + momo.partnerCode +
                "&redirectUrl=" + momo.redirectUrl +"&requestId=" + momo.requestId +"&requestType=" + momo.requestType;
           return momo.signature = HashHelper.HmacSHA256(rawHash, secretKey);
        }
        public (bool, string?) GetLinkGatewayMomo(string paymentUrl,MomoPaymentRequest momoPaymentRequest)
        {
            using HttpClient client = new HttpClient();
            var requestData = JsonConvert.SerializeObject(momoPaymentRequest, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            });
            var requestContent = new StringContent(requestData, Encoding.UTF8, "application/json");

            var createPaymentLink =  client.PostAsync(paymentUrl, requestContent).Result;
            if (createPaymentLink.IsSuccessStatusCode)
            {
                var responseContent = createPaymentLink.Content.ReadAsStringAsync().Result;
                var responeseData = JsonConvert.DeserializeObject<MomoPaymentResponese>(responseContent);
                // return QRcode
                if (responeseData.resultCode == "0") return (true, responeseData.payUrl);
                else return (false, responeseData.message);
            }
            else
                return (false, createPaymentLink.ReasonPhrase);
        }
    }
}
