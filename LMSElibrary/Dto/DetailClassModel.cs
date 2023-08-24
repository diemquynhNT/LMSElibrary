using SubjectService.Model;

namespace SubjectService.Dto
{
    public class DetailClassModel
    {
        public string IdClass { get; set; }
        public string IdSubject { get; set; }
        public string? IdTeacher { get; set; }
    }
}
