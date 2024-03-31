using AutoMapper;
using ClubManager.Application.Clubs.Command.UpdateClub;
using ClubManager.Application.User;
using ClubManager.Domain.Entities;
using ClubManager.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;

namespace ClubManager.Application.Clubs.Command.DeleteClub;
public class DeleteClubCommandHandler(ILogger<UpdateClubCommandHandler> logger, IUserContext userContext, IMapper mapper, IClubRepository clubRepository) : IRequestHandler<DeleteClubCommand, bool>
{
    public async Task<bool> Handle(DeleteClubCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        logger.LogInformation("{UserEmail} [{UserId}] deleted club with Id {@Club}",
        currentUser.Email,
        currentUser.Id,
            request);

        var existingClub = await clubRepository.GetByIdAsync(request.Id);
        if (existingClub == null)
            throw new NotFoundException(nameof(Club), request.Id.ToString());

        await clubRepository.Remove(existingClub);
        return true;
    }
}
