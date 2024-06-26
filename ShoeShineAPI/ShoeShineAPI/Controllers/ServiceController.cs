﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
	[Route("api/services")]
	[ApiController]
	public class ServiceController : Controller
	{
		IServiceService _service;
		IMapper _map;
		IServiceStoreService _serviceStore;

		public ServiceController(IServiceService service, IMapper map, IServiceStoreService serviceStore)
		{
			_service = service;
			_map = map;
			_serviceStore = serviceStore;
		}

		[HttpGet("{storeId}")]
        public async Task<IActionResult> GetServiceByStoreId(int storeId)
		{
			//var serviceStores= await _serviceStore.GetServiceStoreAsync();
			//var services = await _service.GetCategoryByStoreId(serviceStores,storeId);
			var result= await _service.GetServicesByStoreId(storeId);
			if (result.Any())
			{
				var respones = _map.Map<List<ServiceStoreRespone>>(result);
				return Ok(respones);
			}
			return BadRequest("Service Data Is Empty !!!");
		}
		[HttpGet()]
		public async Task<IActionResult> GetAll()
		{
			var services = await _service.GetServicesAsync();
			if (services.Any())
			{
				var serviceMapper = _map.Map<IEnumerable<ServiceRespone>>(services);
				return Ok(serviceMapper);
			}
			return BadRequest("Service Data Is Empty");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveAllServices()
		{
			await _service.RemoveAllServices();
			return NoContent();
		}
		[HttpPost("/add-service-store")]
        public async Task<IActionResult> AddServiceStore(ServiceStoreRequest request)
		{
			var result = await _serviceStore.AddServiceStore(request.StoreId, request.ServiceId,request.Price);
			if (result.Item1) return Ok(result.Item2);
            return Conflict(result.Item2);
        }
        [HttpPut("/cancel-service-store")]
        public async Task<IActionResult> UpdateServiceStore(ServiceStoreRequest request)
        {
            var result = await _serviceStore.UpdateServiceStore(0,null,request.StoreId, request.ServiceId,false);
            if (result) return Ok("Cancel Service Success");
            return Conflict("Cancel Service Fail");
        }
    }
}
