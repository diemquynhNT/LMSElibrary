using System.ComponentModel.DataAnnotations;

namespace ExamService.Model
{
    public class OptionQuestion
    {
        [Key]
        public string IdOptions { get; set; }
        [Required]
        [MaxLength(100)]
        public string ContentOption { get; set; }

        public string? IdQuestion { get; set; }
        public Questions questions { get; set; }
    }
}
