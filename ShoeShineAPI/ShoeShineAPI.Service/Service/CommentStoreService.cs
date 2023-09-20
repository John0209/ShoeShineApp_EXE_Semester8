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
	public class CommentStoreService :CommonAbstract<CommentStoreEntity>, ICommentStoreService
	{
		IUnitRepository _unit;

		public CommentStoreService(IUnitRepository unit)
		{
			_unit = unit;
		}

		public async Task<IEnumerable<CommentStoreEntity>> GetCommentAsync()
		{
			return await GetAllDataAsync();
		}

		public async Task<IEnumerable<CommentStoreEntity>> GetCommentByStoreId(int storeId)
		{
			return await _unit.CommentRepository.GetCommentByStoreId(storeId);
		}

		protected override async Task<IEnumerable<CommentStoreEntity>> GetAllDataAsync()
		{
			return await _unit.CommentRepository.GetAll();
		}
	}
}
