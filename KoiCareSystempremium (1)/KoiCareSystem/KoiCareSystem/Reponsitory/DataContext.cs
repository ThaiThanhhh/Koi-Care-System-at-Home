using KoiCareSystem.Models;
using KoiCareSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystem.Reponsitory
{
    public class DataContext : IdentityDbContext<AppUserModel>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Koi> Kois { get; set; }
        public DbSet<Aquarium> Aquariums { get; set; }
        public DbSet<WaterParameter> WaterParameters { get; set; }
        public DbSet<AppUserModel> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
