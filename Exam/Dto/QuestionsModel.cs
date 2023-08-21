using System.ComponentModel.DataAnnotations;

namespace ExamService.Dto
{
    public class QuestionsModel
    {
        public string ContentQuestion { get; set; }
        public string LevelQuestion { get; set; }


        public string answ { get; set; }

        //public List<OptionQuesModel> Ques { get; set; }
    }
}
