namespace ClubManager.Application.User;
public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}