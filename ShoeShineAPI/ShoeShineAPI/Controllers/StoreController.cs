using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
	[Route("api/store")]
	[ApiController]
	public class StoreController : ControllerBase
	{
		IStoreService _store;
		IMapper _map;

		public StoreController(IStoreService store, IMapper map)
		{
			_store = store;
			_map = map;
		}
		[HttpGet("get-all")]
		public async Task<IActionResult> GetAll()
		{
			var stores=await _store.GetStoresAsync();
			if (stores.Any())
			{
				var storesMapper = _map.Map<IEnumerable<StoreDTO>>(stores);
				return Ok(storesMapper);
			}
			return BadRequest("Store Data Is Empty");
		}
	}
}
