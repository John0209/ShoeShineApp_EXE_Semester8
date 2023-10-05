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
using EllipticCurve.Utils;
using System.Text.RegularExpressions;

namespace ShoeShineAPI.Service.Service
{
    public class PaymentService : CommonAbstract<Transaction>, IPaymentService
    {
        IUnitRepository _unit;
        IOrderService _order;

        public PaymentService(IUnitRepository unit, IOrderService order)
        {
            _unit = unit;   
            _order = order;
        }
        public async Task<bool> CreateTransaction(MomoResultRequest request)
        {
          // Update status order sang confirm
          var updateStatusOrder =await _order.UpdateOrderAfterPaymentSuccess(request.requestId);
          if (updateStatusOrder)
          {
            var transaction = new Transaction();
            // gắn field
            transaction.TransactionId = request.transId;
            transaction.Amount =(float)request.amount;
            transaction.OrderId = GetOrderIdInMomo(request.orderId);
            transaction.TransactionInfor = request.orderInfo;
            transaction.TransactionType = request.orderType;
            transaction.PayType = request.payType;
            await _unit.TransactionRepository.Add(transaction);
            var result= _unit.Save();
            if (result > 0) return true;
          }
            return false;
        }

        private int GetOrderIdInMomo(string orderId)
        {
            Regex regex = new Regex("-(\\d+)");
            var macth= regex.Match(orderId);
            if(macth.Success ) return Int32.Parse(macth.Groups[1].Value);
            return 0;
        }

        protected override Task<IEnumerable<Transaction>> GetAllDataAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<(bool,MomoPaymentRequest)> MapOrderInformation(MomoPaymentRequest request)
        {
            var order = await _order.GetOrderStatusPayment();
            if(order != null)
            {
                request.requestId= order.OrderCode;
                request.amount =(long) order.TotalPrice;
                request.extraData= order.OrderDate.ToString();
                request.orderId ="SSN-"+order.OrderId;
                return (true,request);
            }
            return (false, request);
        }
        public bool IsValidSignatureMomoPayment(string accessKey, string secretKey, MomoResultRequest momo)
        {
            var rawHash = "accessKey=" + accessKey +
                "&amount=" + momo.amount + "&extraData=" + momo.extraData + "&message=" + momo.message +
                 "&orderId=" + momo.orderId +"&orderInfo=" + momo.orderInfo + "&orderType=" + momo.orderType +
                 "&partnerCode=" + momo.partnerCode +"&payType=" + momo.payType + "&requestId=" + momo.requestId 
                 + "&responseTime=" + momo.responseTime + "&resultCode=" + momo.resultCode + "&transId=" + momo.transId;
           var checkSignature = HashHelper.HmacSHA256(rawHash, secretKey);
            return momo.signature.Equals(checkSignature);
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
