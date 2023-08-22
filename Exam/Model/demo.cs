using System.ComponentModel.DataAnnotations;

namespace ExamService.Model
{
    public class demo
    {
        [Key]
        public int id { get; set; }
        public string content { get; set; }
    }
}
