using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetDemo.Models
{
    public partial class DemoBaseContext : DbContext
    {
        public DemoBaseContext()
        {
        }

        public DemoBaseContext(DbContextOptions<DemoBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BattleShip> BattleShip { get; set; }
        public virtual DbSet<Temperature> Temperature { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=DemoBase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BattleShip>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TimeValue).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BattleShip)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BattleShi__UserI__3B75D760");
            });

            modelBuilder.Entity<Temperature>(entity =>
            {
                entity.Property(e => e.TemperatureValue).HasColumnType("float");

                entity.Property(e => e.ThingyName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TimeValue).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__UserData__C9F28456ECF96774")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);
            });
        }
    }
}
