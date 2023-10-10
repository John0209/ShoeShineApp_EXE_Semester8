using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
	public class ServiceStoreService : CommonAbstract<ServiceStore>, IServiceStoreService
	{
		IUnitRepository _unit;

		public ServiceStoreService(IUnitRepository unit)
		{
			_unit = unit;
		}
        public List<int> GetServiceStoreId(int storeId)
        {
            return _unit.ServiceStoreRepository.GetServiceStoreId(storeId); 
        }
        public async Task<ServiceStore?> GetServiceStoreById(int serviceStoreId)
        {
            return await _unit.ServiceStoreRepository.GetById(serviceStoreId);
        }

        public async Task<IEnumerable<ServiceStore>> GetServiceStoreAsync()
		{
			var serviceStores= await GetAllDataAsync();
			return serviceStores;
		}

		protected override async Task<IEnumerable<Core.Model.ServiceStore>> GetAllDataAsync()
		{
			return await _unit.ServiceStoreRepository.GetAll();
		}
		public async Task<(bool,string)> AddServiceStore(int storeId, int[] serviceArray, float[] price)
		{
			if(serviceArray.Length > 0 && storeId > 0)
			{
                int i = 0;
                foreach (var serviceId in serviceArray)
                {
                    var checkStatus = await _unit.ServiceStoreRepository.CheckServiceStoreExist(storeId, serviceId);
                    if (checkStatus == null)
                    {
                        var serviceStore = new ServiceStore();
                        serviceStore.StoreId = storeId;
                        serviceStore.ServiceId = serviceId;
                        serviceStore.IsServiceStoreStatus = true;
                        await _unit.ServiceStoreRepository.Add(serviceStore);
                        if (_unit.Save() == 0) return (false, "Conflict When Add StoreId=" + storeId);
                        // nếu add servicestore success after add service price
                        if (!await AddServicePrice(serviceStore.ServiceStoreId, price[i]))
                            return (false, "Conflict When Add ServicePrice & serviceStoreId=" + serviceStore.ServiceStoreId);
                        i++;
                    }
                    else
                    {
                        var result = await UpdateServiceStore(price[i],checkStatus, 0, Array.Empty<int>(), true);
                        if(!result) return (false, "Conflict When Update Status StoreId=" + storeId);
                        i++;
                    }
                }
                return (true, "Add ServiceStore Success");
            }
			return (false,"Add ServiceStore Fail");
		}

        private async Task<bool> AddServicePrice(int serviceStoreId, float price)
        {
            ServicePrice servicePrice = new ServicePrice();
            servicePrice.ServiceStoreId = serviceStoreId;
            servicePrice.Price = price;
            await _unit.ServicePriceRepository.Add(servicePrice);
            if (_unit.Save() > 0) return true;
            return false;
        }

        public async Task<bool> UpdateServiceStore(float price,ServiceStore? serviceStore,int storeId, int[] serviceArray,bool isCheck)
        {
            switch (isCheck)
            {
                case true:
                    if(serviceStore != null)
                    {
                        serviceStore.IsServiceStoreStatus = isCheck;
                        _unit.ServiceStoreRepository.Update(serviceStore);
                        if (_unit.Save() > 0)
                        {
                            var servicePrice = await _unit.ServicePriceRepository.GetById(serviceStore.ServiceStoreId);
                            if (servicePrice != null)
                            {
                                servicePrice.Price = price;
                                _unit.ServicePriceRepository.Update(servicePrice);
                                _unit.Save();
                            }
                            return true;
                        }
                    }
                    break;
                case false:
                    if (serviceArray.Length > 0 && storeId > 0)
                    {
                        foreach (var serviceId in serviceArray)
                        {
                            var _serviceStore = await _unit.ServiceStoreRepository.CheckServiceStoreExist(storeId, serviceId);
                            if (_serviceStore != null)
                            {
                                _serviceStore.IsServiceStoreStatus = isCheck;
                                _unit.ServiceStoreRepository.Update(_serviceStore);
                                if (_unit.Save() == 0) return false;
                            }
                        }
                        return true;
                    }
                    break;
            }
            return false;
        }


    }
}
