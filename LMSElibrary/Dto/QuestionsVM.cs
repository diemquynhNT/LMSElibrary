using System.ComponentModel.DataAnnotations;

namespace SubjectService.Dto
{
    public class QuestionsVM
    {
       
        public string Title { get; set; }
        public string ContentQuestion { get; set; }
        public string? IdUser { get; set; }
        public DateTime DateCreate { get; set; }
        public bool Favorite { get; set; }

    }
}
