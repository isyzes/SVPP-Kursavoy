using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProviderEntity> Providers { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProviderEntity>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ServiceEntity>()
                .HasKey(s => s.Id);

            // Настройка связи один-ко-многим
            modelBuilder.Entity<ServiceEntity>()
                .HasOne(s => s.Provider)
                .WithMany(p => p.Services)
                .HasForeignKey(s => s.ProviderId);
        }
    }
}
