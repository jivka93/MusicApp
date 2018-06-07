using MusicApplication.Data;

namespace MusicApplication.Services.contracts
{
    public interface IUserService
    {
        User GetUser(string username, string password);

        User UpdateUser(int id, User user);

        User CreateUser(User user);

        bool DeleteUser(int id);
    }
}
