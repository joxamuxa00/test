using DeviceManagement.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Infrastructure;

public class DeviceManagementDbContext : IdentityDbContext<IdentityUser>
{
    public DeviceManagementDbContext(DbContextOptions<DeviceManagementDbContext> options)
        : base(options) { }

    public DbSet<ManDbModel> Men { get; set; }

    public DbSet<StudentDbModel> Students { get; set; }

    public DbSet<GirlDbModel> Girls { get; set; }

    public DbSet<CarDbModel> Cars { get; set; }

    public DbSet<RemoteControlDbModel> RemoteControls { get; set; }

    public DbSet<BalloonDbModel> Balloons { get; set; }

    public DbSet<PhoneDbModel> Phones { get; set; }

    public DbSet<LaptopDbModel> Laptops { get; set; }
}
