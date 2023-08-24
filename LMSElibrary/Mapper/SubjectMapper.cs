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
            CreateMap<QuestionModel, Questions>()
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.ContentQuestion, act => act.MapFrom(src => src.ContentQuestion));
            CreateMap<ClassModel, ClassSubject>()
               .ForMember(dest => dest.NameClass, act => act.MapFrom(src => src.NameClass));
            CreateMap<DetailClassModel, DetailClass>()
                .ForMember(dest => dest.IdSubject, act => act.MapFrom(src => src.IdSubject))
                .ForMember(dest => dest.IdClass, act => act.MapFrom(src => src.IdClass))
              .ForMember(dest => dest.IdTeacher, act => act.MapFrom(src => src.IdTeacher));
            CreateMap<SubjectModel, Subject>()
                .ForMember(dest => dest.NameSubject, act => act.MapFrom(src => src.NameSubject))
                .ForMember(dest => dest.Schoolyear, act => act.MapFrom(src => src.Schoolyear))
              .ForMember(dest => dest.DescribeSubject, act => act.MapFrom(src => src.DescribeSubject))
              .ForMember(dest => dest.StatusSubject, act => act.MapFrom(src => src.StatusSubject))
              .ForMember(dest => dest.IdDepartment, act => act.MapFrom(src => src.IdDepartment));
            CreateMap<Questions, QuestionsVM>()
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.ContentQuestion, act => act.MapFrom(src => src.ContentQuestion))
                 .ForMember(dest => dest.DateCreate, act => act.MapFrom(src => src.DateCreate))
                  .ForMember(dest => dest.Favorite, act => act.MapFrom(src => src.Favorite))
                   .ForMember(dest => dest.IdUser, act => act.MapFrom(src => src.IdUser));


        }



    }
}
