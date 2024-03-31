using MediatR;

namespace ClubManager.Application.Clubs.Command.CreateClub;
public class CreateClubCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
}