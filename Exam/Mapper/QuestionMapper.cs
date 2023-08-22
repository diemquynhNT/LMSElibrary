using AutoMapper;
using ExamService.Dto;
using ExamService.Model;

namespace ExamService.Mapper
{
    public class QuestionMapper :Profile
    {
        public QuestionMapper() {
            CreateMap<QuestionsModel, Questions>()
            .ForMember(dest => dest.ContentQuestion, act => act.MapFrom(src => src.ContentQuestion))
            .ForMember(dest => dest.LevelQuestion, act => act.MapFrom(src => src.LevelQuestion))
            .ForMember(dest => dest.AnswerQuestions, act => act.MapFrom(src => src.AnswerQuestions))
             .ForMember(dest => dest.ChoiceA, act => act.MapFrom(src => src.ChoiceA))
              .ForMember(dest => dest.ChoiceB, act => act.MapFrom(src => src.ChoiceB))
               .ForMember(dest => dest.ChoiceC, act => act.MapFrom(src => src.ChoiceC))
                .ForMember(dest => dest.ChoiceC, act => act.MapFrom(src => src.ChoiceC));
        }
    }
}
