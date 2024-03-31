using Microsoft.AspNetCore.Identity;

namespace ClubManager.Domain.Entities;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Club> OwnedClubs { get; set; } = [];
}
