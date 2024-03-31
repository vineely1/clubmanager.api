using MediatR;

namespace ClubManager.Application.Clubs.Command.DeleteClub;
public class DeleteClubCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
