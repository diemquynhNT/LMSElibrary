namespace SubjectService.Model
{
    public class ChitietLop
    {
        public string IdLop { get; set; }
        public string IdMonHoc { get; set; }
        public MonHoc monHoc { get; set; }
        public Lop lop { get; set; }
    }
}
