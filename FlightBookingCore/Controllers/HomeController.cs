using Microsoft.AspNetCore.Mvc;
using FlightBookingCore.Data; // Thay bằng namespace của bạn
using FlightBookingCore.Models; // Thay bằng namespace của bạn
using System.Linq;
namespace FlightBookingCore.Controllers
{
public class HomeController : Controller
{
private readonly ApplicationDbContext _context;
// Sử dụng Dependency Injection để lấy DbContext
public HomeController(ApplicationDbContext context)
: base() // Nếu có ILogger thì truyền vào đây
{
_context = context;
}
// Action hiển thị trang chủ với form tìm kiếm
public IActionResult Index()
{
return View();
}
// Action xử lý yêu cầu tìm kiếm (POST)
[HttpPost]
public IActionResult Search(string diemDi, string diemDen, DateTime
ngayDi)
{
// Logic tìm kiếm cơ bản bằng LINQ
var results = _context.ChuyenBays
.Where(c => c.DiemDi.Contains(diemDi) &&
c.DiemDen.Contains(diemDen) &&
c.NgayGioKhoiHanh.Date == ngayDi.Date)
.ToList();
// Truyền kết quả tìm kiếm sang View hiển thị kết quả
return View("SearchResults", results);
}
}
}