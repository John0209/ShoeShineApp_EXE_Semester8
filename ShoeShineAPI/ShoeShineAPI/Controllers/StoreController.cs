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
			var stores = await _store.GetStoresAsync();
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
        /// <summary>
        /// Get Store By Id
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpGet("{storeId}")]
        public async Task<IActionResult> GetById(int storeId)
        {
            var store = await _store.GetStoreById(storeId);
            if (store != null)
            {
                var storesMapper = _map.Map<StoreRespone>(store);
                return Ok(storesMapper);
            }
            return NotFound("StoreEntity Data Is Empty");
        }
        /// <summary>
        /// Search Store By Name
        /// </summary>
        /// <param name="storeName"></param>
        /// <returns></returns>
        [HttpGet("search/{storeName}")]
		public async Task<IActionResult> GetStoresByName(string storeName)
		{
			var stores = await _store.GetStoreByName(storeName);
			if (stores.Any())
			{
				var storesMapper = _map.Map<IEnumerable<StoreRespone>>(stores);
				return Ok(storesMapper);
			}
			return NotFound(storeName+" Not Found");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveAllStores()
		{
			await _store.RemoveAllStores();
			return NoContent();
        }
        /// <summary>
        /// Update Store
        /// </summary>
        /// <schema>
        /// {
        /// "storeName": "HelloKitty",
        /// "storeAddress": "HCM",
        /// "storeDescription": "I love shoe, i really love shoe, i will pay to clean shoe, i want marry shoe",
        /// "storePhone": "0123456789",
        /// "storeEmal": "shoe1@example.com",
        /// "url": "string"
        ///}
        /// </schema>
		/// 
        /// <returns>IActionResult containing services or error message</returns>
        [HttpPut]
		public async Task<IActionResult> UpdateStore([FromBody] StoreUpdateRequest request)
		{
			var store =await _store.GetStoreById(request.StoreId);
			if(store != null)
			{
				var _update= _map.Map<Store>(request);
                var result = await _store.UpdateStore(_update,request.Url);
				if(result.Item1) return Ok(result.Item2);
				return Ok(result.Item2);
            }
			return BadRequest("Update Store Fail");
        }

    }
}
