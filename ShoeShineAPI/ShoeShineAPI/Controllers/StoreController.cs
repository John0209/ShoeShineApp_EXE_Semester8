using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Service.Service;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
	[Route("api/stores")]
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
		[HttpGet()]
		public async Task<IActionResult> GetAll()
		{
			var stores=await _store.GetStoresAsync();
			if (stores.Any())
			{
				var storesMapper = _map.Map<IEnumerable<StoreRespone>>(stores);
				return Ok(storesMapper);
			}
			return NotFound("StoreEntity Data Is Empty");
		}

        [HttpPost()]
        public async Task<IActionResult> RegisterStore([FromBody] StoreRequest request)
        {
			var store = _map.Map<Store>(request);
            var result = await _store.RegisterStoreAsync(store,request);
			if (!result.Item1)
			{
				if(result.Item2.Contains("Email")) return Conflict(result.Item2);
				return BadRequest(result.Item2);
			}
			return Ok(result.Item2);
        }

		[HttpGet("{storeName}")]
		public async Task<IActionResult> GetStoresByName(string storeName)
		{
			var stores = await _store.GetStoreByName(storeName);
			if(stores.Any())
			{
                var storesMapper = _map.Map<IEnumerable<StoreRespone>>(stores);
                return Ok(storesMapper);
            }
			return NotFound("Store Data is empty!");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveAllStores()
		{
			await _store.RemoveAllStores();
			return NoContent();
		}
    }
}
