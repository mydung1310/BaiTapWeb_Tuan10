using Microsoft.EntityFrameworkCore;
using FlightBookingCore.Models; // Thay bằng namespace của bạn
namespace FlightBookingCore.Data
{
public class ApplicationDbContext : DbContext
{
    public
    ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
    // Khai báo DbSet cho bảng ChuyenBay
    public DbSet<ChuyenBay> ChuyenBays { get; set; }
    public DbSet<DatVe> DatVes { get; set; }
    // Bạn sẽ thêm các DbSet khác ở đây (SanBay, KhachHang, DatVe)
    }
}