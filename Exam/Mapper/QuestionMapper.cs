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
          .ForMember(dest => dest.AnswerQuestions, act => act.MapFrom(src => src.answ));
        }
    }
}
