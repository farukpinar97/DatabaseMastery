using AutoMapper;
using DatabaseMastery.TransportMongoDb.Dtos.AboutDtos;
using DatabaseMastery.TransportMongoDb.Dtos.BrandDtos;
using DatabaseMastery.TransportMongoDb.Dtos.GetInTouchDtos;
using DatabaseMastery.TransportMongoDb.Dtos.HowItWorkDtos;
using DatabaseMastery.TransportMongoDb.Dtos.OfferDtos;
using DatabaseMastery.TransportMongoDb.Dtos.ProjectSectionDtos;
using DatabaseMastery.TransportMongoDb.Dtos.QuestionDtos;
using DatabaseMastery.TransportMongoDb.Dtos.ShipmentDtos;
using DatabaseMastery.TransportMongoDb.Dtos.ShipmentTrackingDtos;
using DatabaseMastery.TransportMongoDb.Dtos.SliderDtos;
using DatabaseMastery.TransportMongoDb.Dtos.TestimonialDtos;
using DatabaseMastery.TransportMongoDb.Entities;

namespace DatabaseMastery.TransportMongoDb.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Slider,ResultSliderDto>().ReverseMap();
            CreateMap<Slider,CreateSliderDto>().ReverseMap();
            CreateMap<Slider,UpdateSliderDto>().ReverseMap();
            CreateMap<Slider,GetSliderByIdDto>().ReverseMap();

            CreateMap<Brand,ResultBrandDto>().ReverseMap();
            CreateMap<Brand,CreateBrandDto>().ReverseMap();
            CreateMap<Brand,UpdateBrandDto>().ReverseMap();
            CreateMap<Brand,GetBrandByIdDto>().ReverseMap();

            CreateMap<Offer,ResultOfferDto>().ReverseMap();
            CreateMap<Offer,CreateOfferDto>().ReverseMap();
            CreateMap<Offer,UpdateOfferDto>().ReverseMap();
            CreateMap<Offer,GetOfferByIdDto>().ReverseMap();

            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
            CreateMap<About,GetAboutByIdDto>().ReverseMap();

            CreateMap<GetInTouch,ResultGetInTouchDto>().ReverseMap();
            CreateMap<GetInTouch,CreateGetInTouchDto>().ReverseMap();
            CreateMap<GetInTouch,UpdateGetInTouchDto>().ReverseMap();
            CreateMap<GetInTouch,GetGetInTouchByIdDto>().ReverseMap();

            CreateMap<HowItWork,ResultHowItWorkDto>().ReverseMap();
            CreateMap<HowItWork,CreateHowItWorkDto>().ReverseMap();
            CreateMap<HowItWork,UpdateHowItWorkDto>().ReverseMap();
            CreateMap<HowItWork,GetHowItWorkByIdDto>().ReverseMap();

            CreateMap<Testimonial,ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,GetTestimonialByIdDto>().ReverseMap();

            CreateMap<ProjectSection,ResultProjectSectionDto>().ReverseMap();
            CreateMap<ProjectSection,CreateProjectSectionDto>().ReverseMap();
            CreateMap<ProjectSection,UpdateProjectSectionDto>().ReverseMap();
            CreateMap<ProjectSection,GetProjectSectionByIdDto>().ReverseMap();

            CreateMap<Question,ResultQuestionDto>().ReverseMap();
            CreateMap<Question,CreateQuestionDto>().ReverseMap();
            CreateMap<Question,UpdateQuestionDto>().ReverseMap();
            CreateMap<Question,GetQuestionByIdDto>().ReverseMap();

            CreateMap<Shipment,ResultShipmentDto>().ReverseMap();
            CreateMap<Shipment,CreateShipmentDto>().ReverseMap();
            CreateMap<Shipment,UpdateShipmentDto>().ReverseMap();
            CreateMap<Shipment,GetShipmentByIdDto>().ReverseMap();

            CreateMap<ShipmentTracking,CreateShipmentTrackingDto>().ReverseMap();
            CreateMap<ShipmentTracking,UpdateShipmentTrackingDto>().ReverseMap();
            CreateMap<ShipmentTracking,ResultShipmentTrackingDto>().ReverseMap();
        }
    }
}
