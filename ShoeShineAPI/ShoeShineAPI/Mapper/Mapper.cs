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
                                                        src.Images.Select(x=> x.ImageURL).ToList(): new List<string>()))
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
                        otp => otp.MapFrom(src => src.Booking.BookingCategories.Any() ? 
                        src.Booking.BookingCategories.Select(x=> x.Category.CategoryName).ToList(): new List<string>()))
                .ForMember(dest => dest.StoreName,
                        otp => otp.MapFrom(src => src.Booking.Store != null ? src.Booking.Store.StoreName : string.Empty))
                .ReverseMap();

            CreateMap<Booking, BookingRespone>()
                .ForMember(dest => dest.ServiceName,
                        otp => otp.MapFrom(src => src.Service!= null ? src.Service.ServiceName : string.Empty))
                .ForMember(dest => dest.CategoryName,
                      otp => otp.MapFrom(src => src.BookingCategories.Any() ? 
                      src.BookingCategories.Select(x=> x.Category.CategoryName).ToList() : new List<string>()))
                .ForMember(dest => dest.StoreName,
                        otp => otp.MapFrom(src => src.Store != null ? src.Store.StoreName : string.Empty))
                .ReverseMap();

            CreateMap<Transaction, TransactionRespone>()
                .ForMember(dest => dest.OrderCode,
                        otp => otp.MapFrom(src => src.Order != null ? src.Order.OrderCode : string.Empty))
                .ForMember(dest => dest.OrderDate,
                        otp => otp.MapFrom(src => src.Order != null ? src.Order.OrderDate : default))
                .ReverseMap();

            CreateMap<ServiceStore, ServiceStoreRespone>()
                .ForMember(dest => dest.ServiceName,
                        otp => otp.MapFrom(src => src.Service != null ? src.Service.ServiceName : string.Empty))
                 .ForMember(dest => dest.ServicePrice,
                        otp => otp.MapFrom(src => src.ServicePrice != null ? src.ServicePrice.Price : 0))
                  .ForMember(dest => dest.StoreName,
                        otp => otp.MapFrom(src => src.Store != null ? src.Store.StoreName : string.Empty))
                  .ReverseMap();

            CreateMap<CategoryStore, CategoryStoreRespone>()
                .ForMember(dest => dest.CategoryName,
                        otp => otp.MapFrom(src => src.Category != null ? src.Category.CategoryName : string.Empty))
                  .ForMember(dest => dest.StoreName,
                        otp => otp.MapFrom(src => src.Store != null ? src.Store.StoreName : string.Empty))
                  .ReverseMap();

            CreateMap<Store, StoreUpdateRequest>().ReverseMap();
            CreateMap<Store, StoreRequest>().ReverseMap();
            CreateMap<ServiceDB, ServiceRespone>().ReverseMap();
			CreateMap<Category, CategoryRespone>().ReverseMap();
			CreateMap<User, UserRespone>().
                ForMember(dest => dest.UserRole,
                otp => otp.MapFrom(src => src.Role != null ? src.Role.RoleName : string.Empty)).ReverseMap();
			#endregion Mapper-Respone
			//---------------------------------------//
			#region Mapper-Request
			CreateMap<Order, OrderRequest>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailRequest>().ReverseMap();
            CreateMap<Booking, BookingRequest>().ReverseMap();
            CreateMap<CommentStoreRequest, CommentStore>().ReverseMap();
            CreateMap<StoreRequest, Store>().ReverseMap();
            #endregion Mapper-Request
        }
    }
}
