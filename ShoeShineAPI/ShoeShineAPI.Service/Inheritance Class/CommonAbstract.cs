using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Inheritance_Class
{
	public abstract class CommonAbstract<T> where T : class 
	{
		// Method chung để các service class thừa kế, lấy all data của model đó trong database
		protected abstract Task<IEnumerable<T>> GetAllDataAsync();
		// Method này dùng cho lấy service & category của store được truyền id vào
		protected virtual IEnumerable<T>? GetMatchingItems(IEnumerable<int> matchingId, IEnumerable<T> list,
															Func<T,int> getId)
		{
			var query = list.Where(item => matchingId.Contains(getId(item)));
			return query.Any()?query : null;
		}

	}
}
