using Microsoft.AspNetCore.Mvc;
using FlightBookingCore.Data; // Thay bằng namespace của bạn
using FlightBookingCore.Models; // Thay bằng namespace của bạn
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingCore.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Sử dụng Dependency Injection để lấy DbContext
        public BookingController(ApplicationDbContext context)
            : base()
        {
            _context = context;
        }

        // Action hiển thị form đặt vé
        public IActionResult Book(int id) // id là MaChuyenBay được truyền từ trang kết quả
        {
            // Lấy thông tin chuyến bay dựa trên id
            var chuyenBay = _context.ChuyenBays.FirstOrDefault(c => c.MaChuyenBay == id);

            if (chuyenBay == null) // Kiểm tra nếu không tìm thấy chuyến bay
            {
                return NotFound(); // Trả về lỗi 404
            }

            // Tạo một đối tượng DatVe mới và truyền MaChuyenBay sang View
            var datVe = new DatVe
            {
                MaChuyenBay = id,
                ChuyenBay = chuyenBay // Để hiển thị thông tin chuyến bay trên View
            };

            return View(datVe); // Truyền đối tượng DatVe sang View
        }

        // Action xử lý yêu cầu đặt vé (POST)
        [HttpPost]
        [ValidateAntiForgeryToken] // Bảo mật chống tấn công CSRF
        public IActionResult Confirm(DatVe datVe)
        {
            if (ModelState.IsValid) // Kiểm tra nếu dữ liệu nhập vào hợp lệ
            {
                // Lấy thông tin chuyến bay để tính tổng tiền
                var chuyenBay = _context.ChuyenBays.FirstOrDefault(c => c.MaChuyenBay == datVe.MaChuyenBay);

                if (chuyenBay == null) // Kiểm tra nếu không tìm thấy chuyến bay
                {
                    return NotFound(); // Trả về lỗi 404
                }

                // Tính tổng tiền
                datVe.TongTien = chuyenBay.GiaVe * datVe.SoLuongVe;
                datVe.NgayDat = DateTime.Now; // Cập nhật ngày đặt

                // Thêm thông tin đặt vé vào DbSet
                _context.DatVes.Add(datVe);

                // Lưu thay đổi vào CSDL
                _context.SaveChanges();

                // Chuyển hướng đến trang xác nhận đặt vé thành công
                return View("BookingSuccess", datVe);
            }

            // Nếu dữ liệu không hợp lệ, hiển thị lại form đặt vé với các thông báo lỗi
            return View("Book", datVe);
        }
    }
}
