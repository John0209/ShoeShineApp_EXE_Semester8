using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
	public interface IUserRepository : IGenericRepository<User>
	{
        Task<User?> GetUserByEmailAsync(string email);
    }
}
