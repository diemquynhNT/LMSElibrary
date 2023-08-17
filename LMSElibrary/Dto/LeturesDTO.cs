using System.ComponentModel.DataAnnotations;

namespace SubjectService.Dto
{
    public class LeturesDTO
    {
       
        public string TitleLecture { get; set; }
        public string Mota { get; set; }
        public IFormFile ResourcesUpload { get; set; }

    }
}
