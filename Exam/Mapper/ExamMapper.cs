using AutoMapper;
using ExamService.Dto;
using ExamService.Model;

namespace ExamService.Mapper
{
    public class ExamMapper :Profile
    {
        public ExamMapper() {
            CreateMap<ExamModel, Exams>()
                    .ForMember(dest => dest.NameExam, act => act.MapFrom(src => src.NameExam))
                .ForMember(dest => dest.FormatExam, act => act.MapFrom(src => src.FormatExam))
                .ForMember(dest => dest.IdSubject, act => act.MapFrom(src => src.IdSubject))
              .ForMember(dest => dest.TimeExam, opt => opt.MapFrom(src => src.HourExam * 60 + src.MinuteExam));

         
        }
    }
}
