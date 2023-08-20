namespace ExamService.Model
{
    public class DetailExam
    {
        public string IdExam { get; set; }
        public string IdQuestion { get; set; }

        public Exams exam { get; set; }
        public Questions questions { get; set; }
    }
}
