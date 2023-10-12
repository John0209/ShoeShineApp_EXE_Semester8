using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
    public interface IDashboardService
    {
        public Task<(object, object, object, object, string, IEnumerable<string>)> GetUserByMonth(int month);
        public Task<(object, object, object, object, string, IEnumerable<string>)> GetStoreByMonth(int month);
        public Task<(object, object, object, object, string, IEnumerable<string>)>  GetTransactionByMonth(int month);
        public Task<(object, object, object, object, string, IEnumerable<string>)> GetMoneyByMonth(int month);
    }
}
