using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
    public class TransactionService : CommonAbstract<Transaction>, ITransactionService
    {
        IUnitRepository _unit;
        public TransactionService(IUnitRepository unit)
        {
            _unit = unit;
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await GetAllDataAsync();
        }

        protected override async Task<IEnumerable<Transaction>> GetAllDataAsync()
        {
            return await _unit.TransactionRepository.GetAll();
        }
    }
}
