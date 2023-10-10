using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
	[Route("api/categorys")]
	[ApiController]
	public class CategoryController : Controller
	{
		IMapper _map;
		ICategoryService _category;
		ICategoryStoreService _categoryStore;

		public CategoryController(IMapper map, ICategoryService category, ICategoryStoreService categoryStore)
		{
			_map = map;
			_category = category;
			_categoryStore = categoryStore;
		}
		[HttpGet("{storeId}")]
		public async Task<IActionResult> GetCategoryByStoreId(int storeId)
		{
			//var _categoryStores = await _categoryStore.GetCategoriesStoreAsync();
			//var category = await _category.GetCategoriesByStoreId(_categoryStores, storeId);
            var result =await _category.GetCategoryByStoreId(storeId);
            if (result.Any())
            {
                var respones = _map.Map<List<CategoryStoreRespone>>(result);
                return Ok(respones);
            }
            return BadRequest("Category Data Is Empty !!!");
        }
		[HttpGet("get-all")]
		public async Task<IActionResult> GetAll()
		{
			var category = await _category.GetCategoriesAsync();
			if (category.Any())
			{
				var categoryMapper = _map.Map<IEnumerable<CategoryRespone>>(category);
				return Ok(categoryMapper);
			}
			return BadRequest("Category Data Is Empty");
		}
        [HttpPost("/add-category-store")]
        public async Task<IActionResult> AddCategoryStore(CategoryStoreRequest request)
        {
            var result = await _categoryStore.AddCategoryStore(request.StoreId, request.CategoryId);
            if (result.Item1) return Ok(result.Item2);
            return Conflict(result.Item2);
        }
        [HttpPut("/cancel-category-store")]
        public async Task<IActionResult> UpdateCategoryStore(CategoryStoreRequest request)
        {
            var result = await _categoryStore.UpdateCategoryStore(null, request.StoreId, request.CategoryId, false);
            if (result) return Ok("Cancel Category Success");
            return Conflict("Cancel Category Fail");
        }

    }
}
