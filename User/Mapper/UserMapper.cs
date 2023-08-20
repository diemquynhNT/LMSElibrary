using AutoMapper;
using UserService.Dto;
using UserService.Model;

namespace UserService.Mapper
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<UsersModel, Users>()
              .ForMember(dest => dest.Gender, act => act.MapFrom(src => src.Gender))
             .ForMember(dest => dest.Nameus, act => act.MapFrom(src => src.Nameus))
              .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
               .ForMember(dest => dest.Password, act => act.MapFrom(src => src.Password))
                  .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Address))
                  .ForMember(dest => dest.IdPos, act => act.MapFrom(src => src.IdPos))
                  .ForMember(dest => dest.IdClass, act => act.MapFrom(src => src.IdClass))
                  .ForMember(dest => dest.IdKhoa, act => act.MapFrom(src => src.IdKhoa));



            //.ForMember(dest => dest.FullName, opt =>
            // opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
