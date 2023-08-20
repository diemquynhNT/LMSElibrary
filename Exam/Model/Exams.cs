using System.ComponentModel.DataAnnotations;

namespace ExamService.Model
{
    
    public class Exams
    {
        [Key]
        public string IdExam { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameExam { get; set; }
       
        public bool FormatExam { get; set; }
        [Required]
        public int TimeExam { get; set; }
        
        public string? IdTeacher { get; set; }
        public string? IdSubject { get; set; }

        [Required]
        [MaxLength(100)]
        public string StatusExam { get; set; }
        [Required]
        public string FormatFile { get; set; }
        [Required]
        public DateTime DateExam { get; set; }

        public virtual ICollection<DetailExam> detailExam { get; set; }


    }
}
