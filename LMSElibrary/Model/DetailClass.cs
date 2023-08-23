namespace SubjectService.Model
{
    public class DetailClass
    {
        public string IdClass { get; set; }
        public string IdSubject { get; set; }
        public Subject subject { get; set; }
        public ClassSubject classsubject { get; set; }
        public string? IdTeacher { get; set; }
    }
}
