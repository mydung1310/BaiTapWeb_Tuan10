using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookingCore.Models
{
    public class DatVe
    {
        [Key] // Khóa chính
        public int MaDatVe { get; set; }

        [Required]
        public int MaChuyenBay { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên khách hàng")]
        [StringLength(100)]
        [Display(Name = "Họ tên khách hàng")]
        public string HoTenKhachHang { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng vé")]
        [Range(1, 10, ErrorMessage = "Số lượng vé từ 1 đến 10")]
        [Display(Name = "Số lượng vé")]
        public int SoLuongVe { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")] // Kiểu dữ liệu tiền tệ
        [Display(Name = "Tổng tiền")]
        public decimal TongTien { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime NgayDat { get; set; } = DateTime.Now;

        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "Chưa thanh toán"; // Mặc định là "Chưa thanh toán"

        // Khóa ngoại đến bảng ChuyenBay
        [ForeignKey("MaChuyenBay")]
        public virtual ChuyenBay ChuyenBay { get; set; }
    }
}
