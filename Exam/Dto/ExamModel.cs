using System.ComponentModel.DataAnnotations;

namespace ExamService.Dto
{
    public class ExamModel
    {
      
        public string NameExam { get; set; }
        public bool FormatExam { get; set; }
        public int HourExam { get; set; }
        public int MinuteExam { get; set; }
        public string IdSubject { get; set; }

        //public string ContentQuestion { get; set; }
        //public string LevelQuestion { get; set; }
        //public string Answers { get; set; }

        //public List<OptionQuesModel> Ques { get; set; }


    }
}
