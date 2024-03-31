using ClubManager.Application.Clubs.Dtos;
using ClubManager.Application.Common;
using ClubManager.Domain.Constants;
using MediatR;

namespace ClubManager.Application.Clubs.Queries.GetAllClubsQuery;
public class GetAllClubsQuery : IRequest<PagedResult<ClubDto>>
{
    public string? SearchPhrase { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}
