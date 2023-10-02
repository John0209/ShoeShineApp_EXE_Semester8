using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.DTOs;
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
		[HttpGet("get-all")]
		public async Task<IActionResult> GetAll()
		{
			var stores=await _store.GetStoresAsync();
			if (stores.Any())
			{
				var storesMapper = _map.Map<IEnumerable<StoreRespone>>(stores);
				return Ok(storesMapper);
			}
			return BadRequest("StoreEntity Data Is Empty");
		}

        [HttpPost("register")]
        public async Task<IActionResult> RegisterStore([FromBody] StoreRegistrationRespone storeDto)
        {
            var result = await _store.RegisterStoreAsync(storeDto);

            if (result == "Store registration successful")
            {
                return Ok("Store registration successful");
            }
            else if (result == "StoreEmail already exists")
            {
                return Conflict("StoreEmail already exists");
            }
            else
            {
                return BadRequest(result);
            }
        }

		[HttpGet("search/{storeName}")]
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
    }
}
