using AutoMapper;
using DatabaseMastery.DinnerMenuPostgreSQL.Dtos.CategoryDtos;
using DatabaseMastery.DinnerMenuPostgreSQL.Dtos.ContactDtos;
using DatabaseMastery.DinnerMenuPostgreSQL.Dtos.ProductDtos;
using DatabaseMastery.DinnerMenuPostgreSQL.Dtos.ReservationDtos;
using DatabaseMastery.DinnerMenuPostgreSQL.Dtos.ReviewDtos;
using DatabaseMastery.DinnerMenuPostgreSQL.Entities;

namespace DatabaseMastery.DinnerMenuPostgreSQL.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,GetCategoryByIdDto>().ReverseMap();

            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>()
    .ForMember(dest => dest.CategoryName,
               opt => opt.MapFrom(src => src.Category.CategoryName))
    .ReverseMap();
            CreateMap<Product,GetProductByIdDto>().ReverseMap();

            CreateMap<Reservation,CreateReservationDto>().ReverseMap();
            CreateMap<Reservation,UpdateReservationDto>().ReverseMap();
            CreateMap<Reservation,ResultReservationDto>().ReverseMap();
            CreateMap<Reservation,GetReservationByIdDto>().ReverseMap();

            CreateMap<Review,CreateReviewDto>().ReverseMap();
            CreateMap<Review,UpdateReviewDto>().ReverseMap();
            CreateMap<Review, ResultReviewDto>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
            CreateMap<Review,GetReviewByIdDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
        }
    }
}
