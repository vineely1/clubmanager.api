using ClubManager.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infrastructure.Persistance;
internal class ClubManagerDbContext(DbContextOptions<ClubManagerDbContext> options): IdentityDbContext<User>(options)
{
    internal DbSet<Club> Clubs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Club>()
            .OwnsOne(c => c.Address);

        builder.Entity<Club>()
            .HasMany(e => e.Equipment)
            .WithOne()
            .HasForeignKey(c => c.ClubId);

        builder.Entity<User>()
            .HasMany(u => u.OwnedClubs)
            .WithOne(c => c.Owner)
            .HasForeignKey(c => c.OwnerId);
    }
}
