using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service;

public class ServiceService : CommonAbstract<ShoeShineAPI.Core.Model.Service>, IServiceService
{
	IUnitRepository _unit;

	public ServiceService(IUnitRepository unit)
	{
		_unit = unit;
	}

	protected override async Task<IEnumerable<Core.Model.Service>> GetAllData()
	{
		return await _unit.ServiceRepository.GetAll();
	}
}
