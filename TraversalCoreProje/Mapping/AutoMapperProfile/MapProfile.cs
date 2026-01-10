using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOS;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();
            CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();
            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();
            CreateMap<AnnouncementUpdateDTO,Announcement>().ReverseMap();
            CreateMap<SendMessageDTO,ContactUs>().ReverseMap();

        }
    }
}
