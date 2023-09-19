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
	public class CommentStoreService :CommonAbstract<CommentStore>, ICommentStoreService
	{
		IUnitRepository _unit;

		public CommentStoreService(IUnitRepository unit)
		{
			_unit = unit;
		}

		public async Task<IEnumerable<CommentStore>> GetCommentAsync()
		{
			return await GetAllDataAsync();
		}

		public async Task<IEnumerable<CommentStore>> GetCommentByStoreId(int storeId)
		{
			return await _unit.CommentRepository.GetCommentByStoreId(storeId);
		}

		protected override async Task<IEnumerable<CommentStore>> GetAllDataAsync()
		{
			return await _unit.CommentRepository.GetAll();
		}
	}
}
