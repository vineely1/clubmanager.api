using ClubManager.Domain.Entities;

namespace ClubManager.Application.Clubs.Dtos;
public class ClubDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }

    public List<Domain.Entities.Equipment> Equipment { get; set; } = [];

}
