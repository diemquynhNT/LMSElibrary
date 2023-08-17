namespace SubjectService.Model
{
    public class DetailLectures
    {
        public string IdClass { get; set; }
        public string IdLectures { get; set; }
        public Lectures lectures { get; set; }
        public ClassSubject classSubjects { get; set; }
    }
}
