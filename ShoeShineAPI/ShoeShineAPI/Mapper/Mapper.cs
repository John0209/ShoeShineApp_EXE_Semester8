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
            CreateMap<Store, StoreDTO>()
                .ForMember(dest => dest.ImageUrl,
                            opt => opt.MapFrom(src => src.Images != null && src.Images.Any() ?
                                                        src.Images.FirstOrDefault().ImageURL : string.Empty))
                .ForMember(dest => dest.RatingStoreScale,
                            opt => opt.MapFrom(src => src.RatingStores != null ? src.RatingStores.RatingStoreScale : 0))
                .ReverseMap();
            CreateMap<ServiceDB, ServiceDTO>().ReverseMap();
			CreateMap<Category, CategoryDTO>().ReverseMap();
			CreateMap<User, UserDTO>().ReverseMap();
		}
	}
}
