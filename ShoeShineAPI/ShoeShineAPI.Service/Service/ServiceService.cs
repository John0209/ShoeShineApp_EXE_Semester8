using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service;

public class ServiceService : CommonAbstract<Core.Model.Service>, IServiceService
{
	IUnitRepository _unit;
	IServiceStoreService _storeService;

    public ServiceService(IUnitRepository unit, IServiceStoreService storeService)
    {
        _unit = unit;
        _storeService = storeService;
    }



    //public async Task<IEnumerable<Core.Model.Service>> GetCategoryByStoreId(IEnumerable<ServiceStore> serviceStores, int storeId)
    //{
    //	// lấy những serviceId có trong list serviceStores bằng storeId truyển vào
    //	var matchingServiceId = _unit.ServiceStoreRepository.GetServiceIdByStoreId(storeId);
    //	// sau khi có list service Id lọc ra bởi storeId, ta lấy ra list service 
    //	var services = await GetAllDataAsync();
    //	var serviceOfStore = GetMatchingItems(matchingServiceId, services, x=> x.ServiceId);
    //	if (serviceOfStore != null)
    //		return serviceOfStore;
    //	else
    //		return Enumerable.Empty<Core.Model.Service>();
    //}
    protected override async Task<IEnumerable<Core.Model.Service>> GetAllDataAsync()
	{
		return await _unit.ServiceRepository.GetAll();
	}

	public async Task<IEnumerable<Core.Model.Service>> GetServicesAsync()
	{
		var services = await GetAllDataAsync();
		return services;
	}

    public async Task RemoveAllServices()
	{
		var services = await _unit.ServiceRepository.GetAll();
		if (services.Any())
		{
			var serviceStores = await _unit.ServiceStoreRepository.GetAll();
			if (serviceStores.Any())
			{
				_unit.ServiceStoreRepository.RemoveRange(serviceStores);
			}
            _unit.ServiceRepository.RemoveRange(services);
			_unit.Save();
        }
	}
	public async Task<List<ServiceStore>> GetServicesByStoreId(int storeId)
	{
        List<ServiceStore> list = new List<ServiceStore>();
        var serviceStoreIdList= _storeService.GetServiceStoreId(storeId);
		if (serviceStoreIdList.Any())
		{
			foreach(var x in serviceStoreIdList)
			{
				var serviceStore= new ServiceStore();
				serviceStore= await _storeService.GetServiceStoreById(x);
				if(serviceStore != null) list.Add(serviceStore);
			}
		}
		return list;
	}

}
