using AutoMapper;
using ClubManager.Application.Clubs.Dtos;
using ClubManager.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace ClubManager.Application.Clubs.Queries.GetClubByIdQuery;
public class GetClubByIdQueryHandler(ILogger<GetClubByIdQueryHandler> logger, IMapper mapper, IClubRepository clubRepository) : IRequestHandler<GetClubByIdQuery, ClubDto>
{
    public async Task<ClubDto> Handle(GetClubByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Get By Id {request.Id}");
        var club = await clubRepository.GetByIdAsync(request.Id);
        var clubDto = mapper.Map<ClubDto>(club);
        return clubDto;
    }
}
