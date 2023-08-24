using SubjectService.Model;
using System.ComponentModel.DataAnnotations;

namespace SubjectService.Dto
{
    public class SubjectModel
    {
       
        public string NameSubject { get; set; }
        public string Schoolyear { get; set; }
        public string? DescribeSubject { get; set; }
        public bool StatusSubject { get; set; }
        public string? IdDepartment { get; set; }
    }
}
