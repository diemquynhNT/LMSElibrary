using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class Subject
    {
        [Key]
        public string IdSubject { get; set; }
        public string NameSubject { get; set; }
        public string SchoolYear { get; set; }
    }
}
