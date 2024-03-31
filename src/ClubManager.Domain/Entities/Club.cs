namespace ClubManager.Domain.Entities;
public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; }
    public Address? Address { get; set; }
    public User Owner { get; set; }
    public string OwnerId { get; set;}
    public List<Equipment> Equipment { get; set; } = new();
}
