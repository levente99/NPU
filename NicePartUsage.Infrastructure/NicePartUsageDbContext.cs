
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NicePartUsage.Domain.Models;

namespace NicePartUsage.Infrastructure
{
    public class NicePartUsageDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<NpuCreation> NpuCreations { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Element> Elements { get; set; }

        public NicePartUsageDbContext() { } // This one
        public NicePartUsageDbContext(DbContextOptions<NicePartUsageDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=EVH12022NB;Database=NPU;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NpuCreation>()
                .HasMany(npu => npu.Elements)
                .WithMany(e => e.NpuCreations)
                .UsingEntity<NpuCreationElement>();

            modelBuilder.Entity<NpuCreationElement>()
                .HasOne(nce => nce.NpuCreation)
                .WithMany(nc => nc.NpuCreationElements)
                .HasForeignKey(nce => nce.NpuCreationId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete

            modelBuilder.Entity<NpuCreationElement>()
                .HasOne(nce => nce.Element)
                .WithMany(le => le.NpuCreationElements)
                .HasForeignKey(nce => nce.ElementId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete

            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();

            // Disable cascade delete for Score <-> NpuCreation relationship to prevent multiple cascade paths
            modelBuilder.Entity<Score>()
                .HasOne(s => s.NpuCreation)
                .WithMany(nc => nc.Scores)
                .HasForeignKey(s => s.CreationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optionally, you can also disable cascade delete for Score <-> User relationship
            modelBuilder.Entity<Score>()
                .HasOne(s => s.User)
                .WithMany(u => u.Scores)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
