namespace ClubManager.Domain.Entities;
public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public int ClubId { get; set; }
}
