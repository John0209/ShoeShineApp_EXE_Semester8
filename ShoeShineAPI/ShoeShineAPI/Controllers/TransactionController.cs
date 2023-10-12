using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        IMapper _map;
        ITransactionService _transaction;

        public TransactionController(IMapper map, ITransactionService transaction)
        {
            _map = map;
            _transaction = transaction;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions= await _transaction.GetTransactionsAsync();
            if(transactions.Any())
            {
                var result = _map.Map<IEnumerable<TransactionRespone>>(transactions);
                return Ok(result);
            }
            return NotFound("Transaction list is empty!");
        }

    }
}
