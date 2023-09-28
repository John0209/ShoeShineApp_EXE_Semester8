using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
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

		[HttpGet("get-service-of-by-store-id")]
		public async Task<IActionResult> GetServiceByStoreId(int storeId)
		{
			var serviceStores= await _serviceStore.GetServiceStoreAsync();
			var services = await _service.GetServicesByStoreId(serviceStores,storeId);
			if (services.Any())
			{
				var serviceMapper = _map.Map<IEnumerable<ServiceRespone>>(services);
				return Ok(serviceMapper);
			}
			return BadRequest("Service Data Is Empty !!!");
		}
		[HttpGet("get-all")]
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
	}
}
