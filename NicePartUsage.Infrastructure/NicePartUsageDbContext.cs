
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NicePartUsage.Domain.Models;

namespace NicePartUsage.Infrastructure
{
    public class NicePartUsageDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<NpuCreation> NpuCreations { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Element> Elements { get; set; }

        public NicePartUsageDbContext() { }
        public NicePartUsageDbContext(DbContextOptions<NicePartUsageDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NpuCreation>()
                .HasMany(npu => npu.Elements)
                .WithMany(e => e.NpuCreations)
                .UsingEntity<NpuCreationElement>(
                    "NpuCreationElement",
                    e => e.HasOne(e => e.Element).WithMany(e => e.NpuCreationElements).HasForeignKey(e => e.ElementId).HasPrincipalKey(c => c.Id),
                    e => e.HasOne(e => e.NpuCreation).WithMany(e => e.NpuCreationElements).HasForeignKey(e => e.NpuCreationId).HasPrincipalKey(c => c.Id)
                );

            modelBuilder.Entity<NpuCreation>()
                .HasMany(npu => npu.Scores)
                .WithOne(s => s.NpuCreation)
                .HasForeignKey(s => s.CreationId);

            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
