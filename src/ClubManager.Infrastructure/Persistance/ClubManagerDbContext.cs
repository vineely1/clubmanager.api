using ClubManager.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infrastructure.Persistance;
internal class ClubManagerDbContext(DbContextOptions<ClubManagerDbContext> options): IdentityDbContext<User>(options)
{
}
