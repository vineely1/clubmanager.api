using ClubManager.Application.Clubs.Dtos;
using MediatR;

namespace ClubManager.Application.Clubs.Queries.GetClubByIdQuery;
public class GetClubByIdQuery(int id): IRequest<ClubDto>
{
    public int Id { get; set; } = id;
}
