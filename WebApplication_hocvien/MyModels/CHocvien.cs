using System.ComponentModel.DataAnnotations;
using WebApplication_hocvien.Models;

namespace WebApplication_hocvien.MyModels
{
    public class CHocvien
    {
        [Display(Name = "Ma so hoc vien")]
        [Required(ErrorMessage ="Ban chua nhap ma so hoc vien!")]
        public string Mshv { get; set; } = null!;
        [Display(Name = "Ho ten hoc vien")]
        public string? Tenhv { get; set; }
        [Display(Name = "Ngay sinh")]
        [Required(ErrorMessage = "Ban chua nhap ngay sinh!")]
        public DateTime? Ngaysinh { get; set; }
        [Display(Name = "Phai")]
        public bool? Phai { get; set; }
        [Display(Name = "Ma lop")]
        public string? Malop { get; set; }
        public static Lylich chuyendoi(CHocvien x)
        {
            return new Lylich
            {
                Mshv = x.Mshv,
                Tenhv = x.Tenhv,
                Ngaysinh = x.Ngaysinh,
                Phai = x.Phai,
                Malop = x.Malop
            };
        }
        public static CHocvien chuyendoi(Lylich x)
        {
            return new CHocvien
            {
                Mshv = x.Mshv,
                Tenhv = x.Tenhv,
                Ngaysinh = x.Ngaysinh,
                Phai = x.Phai,
                Malop = x.Malop
            };
        }
    }
}
