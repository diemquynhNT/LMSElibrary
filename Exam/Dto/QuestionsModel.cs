using ExamService.Model;
using System.ComponentModel.DataAnnotations;

namespace ExamService.Dto
{
    public class QuestionsModel
    {
        
        public string ContentQuestion { get; set; }
     
        public string LevelQuestion { get; set; }
       
        public string? ChoiceA { get; set; }
        
        public string? ChoiceB { get; set; }
       
        public string? ChoiceC { get; set; }
       
        public string? ChoiceD { get; set; }

        public string AnswerQuestions { get; set; }

    }
}
