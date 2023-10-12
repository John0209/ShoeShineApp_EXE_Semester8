using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Enum;
using ShoeShineAPI.Infracstructure.Repositories;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
    public class DashboardService:IDashboardService
    {
        IUnitRepository _unit;

        public DashboardService(IUnitRepository unit)
        {
            _unit = unit;
        }
        // total, total this month, total last month, numberData, listuserthismonth, compare
        public async Task<(object, object, object, object,string,IEnumerable<string>)> GetUserByMonth(int month)
        {
            var users= await _unit.UserRepository.GetAll();
            var userThisMonth= users.Where(x=> x.UserRegisterDate.Month == month);
            IEnumerable<User>? userLastMonth;
            switch (month)
            {
                case 1:
                    userLastMonth = users.Where(x => x.UserRegisterDate.Year==(DateTime.Now.Year-1)&& x.UserRegisterDate.Month==12);
                    break;
                default:
                    userLastMonth = users.Where(x => x.UserRegisterDate.Month == (month - 1));
                    break;
            }
            var calculate = CalculateData(userThisMonth.Count(), userLastMonth.Count());
            return (users.Count(), userThisMonth.Count(),userLastMonth.Count(),
                    calculate.Item1,calculate.Item2, userThisMonth.Select(x => x.UserName));
        }

        private (object, string) CalculateData(int v1, int v2)
        {
            var number = v1-v2;
            if (v1 > v2) return (number, EnumClass.Compare.Increase.ToString());
            if (v1 < v2) return (number, EnumClass.Compare.Decrease.ToString());
            return (number, EnumClass.Compare.NothingChanges.ToString());
        }
        public async Task<(object, object, object, object, string, IEnumerable<string>)> GetStoreByMonth(int month)
        {
            var stores = await _unit.StoreRepository.GetAll();
            var storeThisMonth = stores.Where(x => x.StoreRegisterDate.Month == month);
            IEnumerable<Store>? storeLastMonth;
            switch (month)
            {
                case 1:
                    storeLastMonth = stores.Where(x => x.StoreRegisterDate.Year == (DateTime.Now.Year - 1) && x.StoreRegisterDate.Month == 12);
                    break;
                default:
                    storeLastMonth = stores.Where(x => x.StoreRegisterDate.Month == (month - 1));
                    break;
            }
            var calculate = CalculateData(storeThisMonth.Count(), storeLastMonth.Count());
            return (stores.Count(), storeThisMonth.Count(), storeLastMonth.Count(),
                    calculate.Item1, calculate.Item2, storeThisMonth.Select(x => x.StoreName));
        }
        public async Task<(object, object, object, object, string, IEnumerable<string>)> GetTransactionByMonth(int month)
        {
            var transactions = await _unit.TransactionRepository.GetAll();
            var transactionThisMonth = transactions.Where(x => x.Order.OrderDate.Month == month);
            IEnumerable<Transaction>? transactionLastMonth;
            switch (month)
            {
                case 1:
                    transactionLastMonth = transactions.Where(x => x.Order.OrderDate.Year == (DateTime.Now.Year - 1) && x.Order.OrderDate.Month == 12);
                    break;
                default:
                    transactionLastMonth = transactions.Where(x => x.Order.OrderDate.Month == (month - 1));
                    break;
            }
            var calculate = CalculateData(transactionThisMonth.Count(), transactionLastMonth.Count());
            return (transactions.Count(), transactionThisMonth.Count(), transactionLastMonth.Count(),
                    calculate.Item1, calculate.Item2, transactionThisMonth.Select(x => x.Order.OrderCode));
        }
        public async Task<(object, object, object, object, string, IEnumerable<string>)> GetMoneyByMonth(int month)
        {
            var transactions = await _unit.TransactionRepository.GetAll();
            var transactionThisMonth = transactions.Where(x => x.Order.OrderDate.Month == month);
            IEnumerable<Transaction>? transactionLastMonth;
            switch (month)
            {
                case 1:
                    transactionLastMonth = transactions.Where(x => x.Order.OrderDate.Year == (DateTime.Now.Year - 1) && x.Order.OrderDate.Month == 12);
                    break;
                default:
                    transactionLastMonth = transactions.Where(x => x.Order.OrderDate.Month == (month - 1));
                    break;
            }
            float totalAmount = TotalMoney(transactions);
            float totalAmountThisMonth = TotalMoneyByMonth(transactionThisMonth);
            float totalAmountLastMonth = TotalMoneyByMonth(transactionLastMonth);
            var calculate = CalculateData((int)totalAmountThisMonth, (int)totalAmountLastMonth);
            return (totalAmount, totalAmountThisMonth, totalAmountLastMonth,
                   calculate.Item1, calculate.Item2, transactionThisMonth.Select(x => x.TransactionType));
        }

        private float TotalMoneyByMonth(IEnumerable<Transaction> transactionByMonth)
        {
            float totalAmountByMonth = 0;
            foreach (var x in transactionByMonth)
            {
                totalAmountByMonth += x.Amount;
            }
            return totalAmountByMonth;
        }

        private float TotalMoney(IEnumerable<Transaction> transactions)
        {
            float totalAmount = 0;    
            foreach (var x in transactions)
            {
                totalAmount += x.Amount;
            }
            return totalAmount;
        }
        
    }
}
