﻿using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Repositories
{
	public class RoleRepository : GenericRepository<Role>, IRoleRepository
	{
		public RoleRepository(DbContextClass context) : base(context)
		{
		}
	}
}
