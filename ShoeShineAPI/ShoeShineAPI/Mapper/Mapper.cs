using AutoMapper;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Core.ResponeModel;
using ServiceDB = ShoeShineAPI.Core.Model.Service;

namespace ShoeShineAPI.Mapper
{
	public class Mapper: Profile
	{
		public Mapper() 
		{
            #region Mapper-Respone
            CreateMap<Store, StoreRespone>()
                .ForMember(dest => dest.ImageUrl,
                            opt => opt.MapFrom(src => src.Images != null && src.Images.Any() ?
                                                        src.Images.FirstOrDefault().ImageURL : string.Empty))
                .ForMember(dest => dest.RatingScale,
                            opt => opt.MapFrom(src => src.Ratings != null ? src.Ratings.RatingScale : 0))
                .ReverseMap();

			CreateMap<CommentStore, CommentStoreRespone>().
				ForMember(dest => dest.RatingComment,
						otp => otp.MapFrom(src => src.Ratings != null ? src.Ratings.RatingScale : 0))
				.ForMember(dest => dest.ImageComments,
						otp => otp.MapFrom(src => src.ImageComments != null && src.ImageComments.Any() ? src.ImageComments.
						Select(x=> x.ImageCommentURL).ToList() : new List<string>() ))
				.ForMember(dest => dest.UserName,
						otp => otp.MapFrom(src => src.User != null ? src.User.UserName : string.Empty))
				.ForMember(dest => dest.StoreName,
						otp => otp.MapFrom(src => src.Store != null ? src.Store.StoreName : string.Empty))
				.ReverseMap();

			CreateMap<Order, OrderRespone>().ForMember(dest => dest.UserName,
						otp => otp.MapFrom(src => src.User != null ? src.User.UserName : string.Empty)).ReverseMap();

            CreateMap<OrderDetail, OrderDetailRespone>()
				.ForMember(dest => dest.ServiceName,
                        otp => otp.MapFrom(src => src.Booking.Service != null ? src.Booking.Service.ServiceName : string.Empty))
				.ForMember(dest => dest.CategoryName,
                        otp => otp.MapFrom(src => src.Booking.Category != null ? src.Booking.Category.CategoryName : string.Empty))
                .ForMember(dest => dest.StoreName,
                        otp => otp.MapFrom(src => src.Booking.Store != null ? src.Booking.Store.StoreName : string.Empty))
                .ReverseMap();

            CreateMap<ServiceDB, ServiceRespone>().ReverseMap();
			CreateMap<Category, CategoryRespone>().ReverseMap();
			CreateMap<User, UserRespone>().ReverseMap();
			#endregion Mapper-Respone
			//---------------------------------------//
			#region Mapper-Request
			CreateMap<Order, OrderRequest>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailRequest>().ReverseMap();
            CreateMap<Booking, BookingRequest>().ReverseMap();
            #endregion Mapper-Request
        }
    }
}
