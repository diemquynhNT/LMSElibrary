using System.ComponentModel.DataAnnotations;

namespace SubjectService.Model
{
    public class ChiTietBaiGiang
    {
        public string IdLop { get; set; }
        public string IdBaiGiang { get; set; }
        public DateTime NgayPC { get; set; }

        public BaiGiang baiGiang { get; set; }
        public Lop lop { get; set; }

    }
}
