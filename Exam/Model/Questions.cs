using System.ComponentModel.DataAnnotations;

namespace ExamService.Model
{
    public class Questions
    {
        [Key]
        public string IdQuestion { get; set; }
        public int STT { get; set; }
        [Required]
        public string ContentQuestion { get; set; }
        [Required]
        public string LevelQuestion { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        [Required]
        public string IdMon { get; set; }
     
        public string? ChoiceA { get; set; }
    
        public string? ChoiceB { get; set; }
       
        public string? ChoiceC { get; set; }
  
        public string? ChoiceD { get; set; }


        [Required]
        public string AnswerQuestions { get; set; }
        [Required]
        public string IdUser { get; set; }
        public string? IdUserUpdate { get; set; }

        public virtual ICollection<DetailExam> detailExam { get; set; }



    }
}
