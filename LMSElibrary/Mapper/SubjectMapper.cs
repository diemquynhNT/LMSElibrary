using AutoMapper;
using SubjectService.Dto;
using SubjectService.Model;

namespace SubjectService.Mapper
{
    public class SubjectMapper:Profile
    {
        public SubjectMapper() {
            CreateMap<LecturesModel, Lectures>()
                .ForMember(dest => dest.IdTopic, act => act.MapFrom(src => src.IdTopic))
                .ForMember(dest => dest.Describe, act => act.MapFrom(src => src.Describe))
                .ForMember(dest => dest.TitleLecture, act => act.MapFrom(src => src.TitleLecture));
                  
        }

    }
}
