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

			CreateMap<CommentStore, CommentStoreDTO>().
				ForMember(dest => dest.RatingComment,
						otp => otp.MapFrom(src => src.RatingComment != null ? src.RatingComment.RatingCommentScale : 0))
				.ForMember(dest => dest.ImageComments,
						otp => otp.MapFrom(src => src.ImageComments != null && src.ImageComments.Any() ? src.ImageComments.
						Select(x=> x.ImageCommentURL).ToList() : new List<string>() ))
				.ForMember(dest => dest.UserName,
						otp => otp.MapFrom(src => src.User != null ? src.User.UserName : string.Empty))
				.ForMember(dest => dest.StoreName,
						otp => otp.MapFrom(src => src.Store != null ? src.Store.StoreName : string.Empty))
				.ReverseMap();

            CreateMap<ServiceDB, ServiceDTO>().ReverseMap();
			CreateMap<Category, CategoryDTO>().ReverseMap();
			CreateMap<User, UserDTO>().ReverseMap();
		}
	}
}
