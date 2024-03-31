using ClubManager.Domain.Entities;

namespace ClubManager.Domain.Repositories;
public interface IClubRepository
{
    Task<(IEnumerable<Club>, int)> GetAllAsync(int skip, int take);
    Task<int> Create(Club club);
    Task Remove(Club club);
    Task UpdateAsync();
    Task<Club> GetByIdAsync(int id);
}
