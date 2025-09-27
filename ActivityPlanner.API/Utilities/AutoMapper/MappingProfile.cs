
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
            CreateMap<Activity,ActivityCreateDto>().ReverseMap();
            CreateMap<Activity,ActivityDeleteDto>().ReverseMap();
            CreateMap<Activity,ActivityUpdateDto>().ReverseMap();
            CreateMap<Activity,ActivityResponseDto>().ReverseMap();
            
            CreateMap<Subscriber,SubscriberCreateDto>().ReverseMap();
            CreateMap<Subscriber, SubscriberDeleteDto>().ReverseMap();
            CreateMap<Subscriber, SubscriberUpdateDto>().ReverseMap();
            CreateMap<Subscriber, SubscriberResponseDto>().ReverseMap();

            CreateMap<UserForRegistrationDto, AppUser>();
        }
    }
}
