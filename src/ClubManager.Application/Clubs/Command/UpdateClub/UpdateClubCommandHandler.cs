using AutoMapper;
using ClubManager.Application.User;
using ClubManager.Domain.Entities;
using ClubManager.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;

namespace ClubManager.Application.Clubs.Command.UpdateClub;
public class UpdateClubCommandHandler(ILogger<UpdateClubCommandHandler> logger, IUserContext userContext, IMapper mapper, IClubRepository clubRepository) : IRequestHandler<UpdateClubCommand, int>
{
    public async Task<int> Handle(UpdateClubCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        logger.LogInformation("{UserEmail} [{UserId}] created club {@Club}",
        currentUser.Email,
        currentUser.Id,
            request);

        var existingClub = await clubRepository.GetByIdAsync(request.Id);
        if (existingClub == null)
            throw new NotFoundException(nameof(Club), request.Id.ToString());

        mapper.Map(request, existingClub);
        await clubRepository.UpdateAsync();
        return existingClub.Id;
    }
}
