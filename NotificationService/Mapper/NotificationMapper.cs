using AutoMapper;
using NotificationService.Dto;
using NotificationService.Model;

namespace NotificationService.Mapper
{
    public class NotificationMapper:Profile
    {
        public NotificationMapper() {
            CreateMap<NotificationModel, Notifications>()
             .ForMember(dest => dest.ContentNotification, act => act.MapFrom(src => src.ContentNotification))
             .ForMember(dest => dest.TitleNotification, act => act.MapFrom(src => src.TitleNotification));
             //.ForMember(dest => dest.Idreceiver, act => act.MapFrom(src => src.Idreceiver));



        }
    }
}
