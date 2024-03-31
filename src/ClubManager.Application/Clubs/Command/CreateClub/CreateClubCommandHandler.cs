using AutoMapper;
using ClubManager.Application.User;
using ClubManager.Domain.Entities;
using ClubManager.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClubManager.Application.Clubs.Command.CreateClub;
public class CreateClubCommandHandler(ILogger<CreateClubCommandHandler> logger, IMapper mapper, IClubRepository clubRepository, IUserContext userContext) : IRequestHandler<CreateClubCommand, int>
{
    public async Task<int> Handle(CreateClubCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        logger.LogInformation("{UserEmail} [{UserId}] created club {@Club}",
            currentUser.Email,
            currentUser.Id,
            request);

        var club = mapper.Map<Club>(request);
        club.OwnerId = currentUser.Id;

        int id = await clubRepository.Create(club);
        return id;
    }
}
