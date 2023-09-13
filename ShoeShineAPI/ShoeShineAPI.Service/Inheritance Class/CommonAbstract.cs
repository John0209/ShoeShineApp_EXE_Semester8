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
		protected abstract Task<IEnumerable<T>> GetAllData();

	}
}
