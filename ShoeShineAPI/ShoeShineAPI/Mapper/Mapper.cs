using AutoMapper;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ServiceDB = ShoeShineAPI.Core.Model.Service;

namespace ShoeShineAPI.Mapper
{
	public class Mapper: Profile
	{
		public Mapper() 
		{ 
			CreateMap<Store,StoreDTO>().ReverseMap();
			CreateMap<ServiceDB, ServiceDTO>().ReverseMap();
			CreateMap<Category, CategoryDTO>().ReverseMap();
			CreateMap<User, UserDTO>().ReverseMap();
		}
	}
}
