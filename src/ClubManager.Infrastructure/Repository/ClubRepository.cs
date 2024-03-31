using ClubManager.Domain.Entities;
using ClubManager.Domain.Repositories;
using ClubManager.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Infrastructure.Repository;
internal class ClubRepository(ClubManagerDbContext dbContext) : IClubRepository
{
    public async Task<int> Create(Club club)
    {
        dbContext.Clubs.Add(club);
        await dbContext.SaveChangesAsync();
        return club.Id;
    }

    public async Task<Club> GetByIdAsync(int id)
    {
        return dbContext.Clubs.Include(c => c.Equipment).FirstOrDefault(c => c.Id == id);
    }

    public async Task<(IEnumerable<Club>, int)> GetAllAsync(int skip, int take)
    {
        var clubs = await dbContext.Clubs.Skip(skip).Take(take).ToListAsync();
        var totalCount = await dbContext.Clubs.CountAsync();

        return (clubs, totalCount);
    }

    public async Task UpdateAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task Remove(Club club)
    {
        dbContext.Remove(club);
        await dbContext.SaveChangesAsync();
    }
}
