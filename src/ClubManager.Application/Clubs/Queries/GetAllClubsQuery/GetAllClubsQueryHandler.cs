using AutoMapper;
using ClubManager.Application.Clubs.Dtos;
using ClubManager.Application.Common;
using ClubManager.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClubManager.Application.Clubs.Queries.GetAllClubsQuery;
public class GetAllClubsQueryHandler(ILogger<GetAllClubsQueryHandler> logger, IMapper mapper, IClubRepository clubRepository) : IRequestHandler<GetAllClubsQuery, PagedResult<ClubDto>>
{
    public async Task<PagedResult<ClubDto>> Handle(GetAllClubsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get All Clubs");
        var (clubs, totals) = await clubRepository.GetAllAsync(request.Skip, request.Take);

        var clubDtos = mapper.Map<IEnumerable<ClubDto>>(clubs);

        var result = new PagedResult<ClubDto>(clubDtos, totals, request.Skip, request.Take);
        return result;
    }
}
