using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystem.CSDL
{
    public partial class KoiCareSystemContext : DbContext
    {
        public KoiCareSystemContext()
        {
        }

        public KoiCareSystemContext(DbContextOptions<KoiCareSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaKoi> CaKois { get; set; }
        public virtual DbSet<HoCa> HoCas { get; set; }
        public virtual DbSet<HoCaKoi> HoCaKois { get; set; }
        public virtual DbSet<TaiKhoanDn> TaiKhoanDns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=LINH\\HOAILINH;Initial Catalog=KoiCareSystem;Integrated Security=True;User ID=sa;Password=123456;Trust Server Certificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaKoi>(entity =>
            {
                entity.HasKey(e => e.MaCa).HasName("PK__CaKoi__27258E7B0695238B");

                entity.ToTable("CaKoi");

                entity.Property(e => e.CanNang).HasColumnType("decimal(10, 2)");
                //entity.Property(e => e.Gia).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.GioiTinh).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.GiongCa).HasMaxLength(100).IsUnicode(false);
                //entity.Property(e => e.HinhAnh).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.KichThuoc).HasColumnType("decimal(10, 2)");
                //entity.Property(e => e.KieuDang).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.TenCa).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.XuatXu).HasMaxLength(100).IsUnicode(false);

                //entity.HasOne(d => d.MaHoNavigation)
                //    .WithMany(p => p.CaKoi)
                //    .HasForeignKey(d => d.MaHo)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("FK__CaKoi__MaHo__31EC6D26");
            });

            ////modelBuilder.Entity<CaKoi>(entity =>
            ////{
            ////    entity.HasKey(e => e.HoId).HasName("PK__HoCa__6D30D254E229EA44");

            ////    entity.ToTable("HoCa");

            ////    entity.Property(e => e.HoId).HasColumnName("HoID");
            ////    entity.Property(e => e.CongSuatMayBom).HasColumnType("decimal(10, 2)");
            ////    entity.Property(e => e.DoSau).HasColumnType("decimal(10, 2)");
            ////    //entity.Property(e => e.HinhAnh).HasMaxLength(255).IsUnicode(false);
            ////    entity.Property(e => e.KichThuoc).HasColumnType("decimal(10, 2)");
            ////    entity.Property(e => e.TenHo).HasMaxLength(100).IsUnicode(false);
            ////    entity.Property(e => e.TheTich).HasColumnType("decimal(10, 2)");
            ////});
            modelBuilder.Entity<HoCa>(entity =>
            {
                entity.HasKey(e => e.HoId).HasName("PK_HoCa");

                entity.ToTable("HoCa");

                entity.Property(e => e.HoId).HasColumnName("HoID");
                entity.Property(e => e.TenHo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KichThuoc)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DoSau)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TheTich)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SoLuongOngThoatNuoc)
                    .HasColumnType("int");

                entity.Property(e => e.CongSuatMayBom)
                    .HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<HoCaKoi>(entity =>
            {
                entity.HasKey(e => e.MaHo).HasName("PK__HoCaKoi__2725A6CBC05BCBE5");

                entity.ToTable("HoCaKoi");

                entity.Property(e => e.CongSuatMayBom).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.DoSau).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.HinhAnh).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.KichThuoc).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.TenHo).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.TheTich).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<TaiKhoanDn>(entity =>
            {
                entity.HasKey(e => e.TaiKhoanId) // Use the new primary key
                    .HasName("PK_TaiKhoanDn"); // Naming the primary key constraint

                entity.ToTable("TaiKhoanDN");

                entity.Property(e => e.TaiKhoanId) // Ensure the primary key property is defined
                    .ValueGeneratedOnAdd(); // Set to auto-generate values

                entity.Property(e => e.Matkhau)
                    .IsRequired() // Make sure this field is required
                    .HasMaxLength(50);

                entity.Property(e => e.Taikhoan)
                    .IsRequired() // Make sure this field is required
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
