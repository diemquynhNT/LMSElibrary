using SubjectService.Model;
using System.ComponentModel.DataAnnotations;

namespace SubjectService.Dto
{
    public class LecturesModel
    {
       
        public string TitleLecture { get; set; }
        public string? Describe { get; set; }
        public string? IdTopic { get; set; }

    }
}
