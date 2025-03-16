
using ActivityPlanner.Entities.DTOs.Activites;
using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.DTOs.Auth;
using ActivityPlanner.Entities.DTOs.Subscriber;
using ActivityPlanner.Entities.Models;
using AutoMapper;

namespace ActivityPlanner.API.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity,ActivityCreateRequestModel>().ReverseMap();
            CreateMap<Activity,ActivityDeleteRequestModel>().ReverseMap();
            CreateMap<Activity,ActivityUpdateRequestModel>().ReverseMap();
            CreateMap<Activity,ActivityResponseModel>().ReverseMap();
            
            CreateMap<Subscriber,SubscriberCreateModel>().ReverseMap();
            CreateMap<Subscriber, SubscriberDeleteModel>().ReverseMap();
            CreateMap<Subscriber, SubscriberUpdateModel>().ReverseMap();
            CreateMap<Subscriber, SubscriberResponseModel>().ReverseMap();

            CreateMap<UserForRegistrationDto, AppUser>();
        }
    }
}
