using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FlightBookingCore.Models
{
public class ChuyenBay{
        [Key] // Khóa chính
        public int MaChuyenBay { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm đi")]
        [StringLength(50)]
        [Display(Name = "Điểm đi")]
        public string DiemDi { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm đến")]
        [StringLength(50)]
        [Display(Name = "Điểm đến")]
        public string DiemDen { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ngày giờ khởi hành")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày giờ khởi hành")]
        public DateTime NgayGioKhoiHanh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá vé")]
        [Column(TypeName = "decimal(18, 2)")] // Kiểu dữ liệu tiền tệ trong SQL
        [Display(Name = "Giá vé")]
        public decimal GiaVe { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số ghế trống")]
        [Display(Name = "Số ghế trống")]
        public int SoGheTrong { get; set; }
    }
}