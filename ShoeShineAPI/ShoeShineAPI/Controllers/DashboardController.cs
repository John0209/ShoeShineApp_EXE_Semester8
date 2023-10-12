using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Enum;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
    [Route("api/dashboards")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        IDashboardService _dashboard;
        IMapper _map;

        public DashboardController(IDashboardService dashboard, IMapper map)
        {
            _dashboard = dashboard;
            _map = map;
        }
        
        /// <summary>
        /// Get Data By Month
        /// </summary>
        /// <remarks> Return 3 Field, (int,int,List), int the first is the total number of users in the database, 
        /// int the second is the total users registered in month and list the last is list of users by month</remarks>
        /// <param name="month"> Month from 1 to 12 </param>
        /// <param name="option">1.User, 2.Store, 3.Transaction, 4.Money</param>
        /// <returns></returns>
        [HttpGet("{month}")]
        public async Task<IActionResult> GetUserByMonth(int month,EnumClass.DashboardOption option)
        {
            if(month >=1 && month <= 12)
            {
                (object, object, object, object, string, IEnumerable<string>) result =default;
                switch ((int)option)
                {
                    case 1:
                        result = await _dashboard.GetUserByMonth(month);
                        break;
                    case 2:
                        result= await _dashboard.GetStoreByMonth(month);
                        break;
                    case 3:
                        result = await _dashboard.GetTransactionByMonth(month);
                        break;
                    case 4:
                        result = await _dashboard.GetMoneyByMonth(month);
                        return Ok(new
                        {
                            TotalAmount = result.Item1,
                            TotalAmountThisMonth = result.Item2,
                            TotalAmountLastMonth = result.Item3,
                            TotalAmountChange = result.Item4,
                            Compare = result.Item5,
                            TransactionType = result.Item6.First()
                        });
                }
                return Ok(new
                {
                    Total = result.Item1, TotalThisMonth=result.Item2,
                    TotalLastMonth = result.Item3, NumberOfChange= result.Item4, Compare= result.Item5, ListThisMonth= result.Item6
                });
            }
            return BadRequest("Month >= 1 && Month <= 12");
        }




    }
}
