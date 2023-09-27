using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
	[Route("api/category")]
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
		[HttpGet("get-category-of-by-store-id")]
		public async Task<IActionResult> GetCategoryByStoreId(int storeId)
		{
			var _categoryStores = await _categoryStore.GetCategoriesStoreAsync();
			var category = await _category.GetCategoriesByStoreId(_categoryStores, storeId);
			if (category.Any())
			{
				var categoryMapper = _map.Map<IEnumerable<CategoryRespone>>(category);
				return Ok(categoryMapper);
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
	}
}
