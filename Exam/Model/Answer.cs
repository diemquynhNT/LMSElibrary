using System.ComponentModel.DataAnnotations;

namespace ExamService.Model
{
    public class Answer
    {
        [Key]
        public string IdAnswer { get; set; }
        [Required]
        public string ContentAnswer { get; set; }

      
        public string? IdQuestion { get; set; }
        public Questions questions { get; set; }
    }
}
